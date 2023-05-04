using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_ApplicationService.Contracts;
using CurrencyConvertor.Application.Contracts.ConvertRateContracts;
using CurrencyConvertor.Application.Contracts.CurrencyContracts;
using CurrencyConvertor.Domain.ConvertRateAgg;
using CurrencyConvertor.Domain.CurrencyAgg;
using QuickGraph;
using QuickGraph.Algorithms;

namespace _01_ApplicationService.Query
{
    public class CurrencyConvertor : ICurrencyConvertor
    {
        //keep the string (ConvertRate) and double(rate value)
        public readonly ConcurrentDictionary<string, double> _rateDictionary =
            new ConcurrentDictionary<string, double>();

        //Keep the graph of convert Rates to find the shortest way from to 
        public readonly AdjacencyGraph<string, Edge<string>> _currencyRouteGraph =
            new AdjacencyGraph<string, Edge<string>>();

        //To implement multi thread safe
        private static readonly object _lockObject = new object();


        private readonly ICurrencyApplication _currencyApplication;
        private readonly IConvertRateApplication _convertRateApplication;

        public CurrencyConvertor(ICurrencyApplication currencyApplication, IConvertRateApplication convertRateApplication)
        {
            _currencyApplication = currencyApplication;
            _convertRateApplication = convertRateApplication;
        }

        public void ClearConfiguration()
        {
            //lock it to safe multi threading 
            lock (_lockObject)
            {
                _rateDictionary.Clear();
                _convertRateApplication.Clear();
            }
        }


        public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates)
        {
            Parallel.ForEach(conversionRates, convertRate =>
            {
                string originCurrency = convertRate.Item1.ToUpper();
                string destinationCurrency = convertRate.Item2.ToUpper();
                double amount = convertRate.Item3;
                string key = $"{originCurrency}_{destinationCurrency}";
                string reverseKey = $"{destinationCurrency}_{originCurrency}";
                double reverseAmount = 1 / amount;
                EditConvertRate convertRateEdit = _convertRateApplication.GetConvertRateBy(originCurrency, destinationCurrency);
                //if the convert rate exist before
                if (convertRateEdit != null)
                {
                    double oldAmount = convertRateEdit.RateFromSourceToDestination;
                    double reverseOldAmount = 1 / oldAmount;
                    convertRateEdit.RateFromSourceToDestination = amount;
                    _convertRateApplication.Edit(convertRateEdit);
                    _rateDictionary.TryUpdate(key, amount, oldAmount);

                    _rateDictionary.TryUpdate(reverseKey, reverseAmount, reverseOldAmount);
                }
                //if the convert rate doesn't exist before
                else
                {
                    long sourceCurrencyId = _currencyApplication.GetIdBy(originCurrency);
                    long destinationCurrencyId = _currencyApplication.GetIdBy(destinationCurrency);
                    CreateConvertRate createCommand = new CreateConvertRate
                    {
                        FkSourceCurrencyId = sourceCurrencyId,
                        
                        FkDestinationCurrencyId = destinationCurrencyId,
                        
                        RateFromSourceToDestination = amount
                    }; 
                    _convertRateApplication.Create(createCommand);
                    _rateDictionary.TryAdd(key, amount);
                    _rateDictionary.TryAdd(reverseKey, reverseAmount);
                }
                lock (_lockObject)
                {
                    if (_currencyRouteGraph.ContainsEdge(originCurrency, destinationCurrency) == false)
                    {
                        _currencyRouteGraph.AddVerticesAndEdge(new Edge<string>(originCurrency, destinationCurrency));
                        _currencyRouteGraph.AddVerticesAndEdge(new Edge<string>(destinationCurrency, originCurrency));
                    }
                }
            });
        }

        public double Convert(string fromCurrency, string toCurrency, double amount)
        {
            lock (_lockObject)
            {
                string originCurrency = fromCurrency.ToUpper();
                string destinationCurrency = toCurrency.ToUpper();

                //findout there is any way to convert
                //Todo write function to get the weight from ConvertRates Table
                Func<Edge<string>, double> graphWeight = e => 1;


                TryFunc<string, IEnumerable<Edge<string>>> tryGetPath = _currencyRouteGraph.ShortestPathsDijkstra(graphWeight, fromCurrency);

                //There isn't any path
                if (tryGetPath == null)
                    //todo: make enum to results
                    return -1;
                IEnumerable<Edge<string>> path;
                //keep the total rate that multiple with amount to get converted amount
                double totalRate = 1;
                if (tryGetPath(destinationCurrency, out path))
                {
                    foreach (var edge in path)
                    {
                        string key = $"{edge.Source}_{edge.Target}";
                        totalRate *= _rateDictionary[key];
                    }

                    return totalRate * amount;
                }
                //there isn't any path to the desired currency
                return -2;

            }
        }
    }
}
