using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ApplicationService.Contracts
{
   public interface ICurrencyConvertor
   {
       /// <summary>
       /// Clear any prior configuration
       /// </summary>
       void ClearConfiguration();

        /// <summary>
        /// Updates configuration.Rates are inserted or update internally;
        /// </summary>
       void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates);

        /// <summary>
        /// Converts the specified amount to the desired currency
        /// </summary>
        /// <param name="fromCurrency">represent the origin currency</param>
        /// <param name="toCurrency">represent the target currency</param>
        /// <param name="amount">amount of how much you want change from <paramref name="fromCurrency"/> to the <paramref name="toCurrency"/></param>
        /// <returns>the value of changed from <paramref name="fromCurrency"/> to the <paramref name="toCurrency"/></returns>
        double Convert(string fromCurrency, string toCurrency, double amount);


   }
}
