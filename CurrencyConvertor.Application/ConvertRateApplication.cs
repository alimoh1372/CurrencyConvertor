using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using CurrencyConvertor.Application.Contracts.ConvertRateContracts;

namespace CurrencyConvertor.Application
{
    /// <summary>
    /// Implementing the <see cref="IConvertRateApplication"/>
    /// </summary>
   public class ConvertRateApplication : IConvertRateApplication
    {
        public OperationResult Create(CreateConvertRate command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditConvertRate command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Active(long id)
        {
            throw new NotImplementedException();
        }

        public OperationResult DeActive(long id)
        {
            throw new NotImplementedException();
        }

        public EditConvertRate GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ConvertRateViewModel> Search(ConvertRateSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public EditConvertRate GetConvertRateBy(string originCurrency, string destinationCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
