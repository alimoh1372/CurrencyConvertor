using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CurrencyConvertor.Domain.ConvertRateAgg;

namespace CurrencyConvertor.Domain.CurrencyAgg
{
    /// <summary>
    /// entity of currency 
    /// </summary>
    public class Currency:EntityBase
    {
        /// <summary>
        /// Short name of currency
        /// </summary>
        public string ShortName { get; private set; }

        /// <summary>
        /// Complete name of Currency
        /// </summary>
        public string CompleteName { get; private set; }

        /// <summary>
        /// Have many <see cref="ConvertRate"/> for source currency
        /// </summary>
        public ICollection<ConvertRate> SourceConvertRates { get; private set; }

        /// <summary>
        /// Have many <see cref="ConvertRate"/> for destination currency
        /// </summary>
        public ICollection<ConvertRate> DestinationConvertRates { get; private set; }
        /// <summary>
        /// To Create <see cref="Currency"/>
        /// </summary>
        /// <param name="shortName">Short Name of Currency</param>
        /// <param name="completeName">Complete Name of Currency</param>
        public Currency(string shortName, string completeName)
        {
            ShortName = shortName;
            CompleteName = completeName;
        }

        /// <summary>
        /// To Edit The <see cref="ShortName"/> and <see cref="CompleteName"/> of  <see cref="Currency"/> <see cref="Currency"/>
        /// </summary>
        /// <param name="shortName">Short Name of Currency</param>
        /// <param name="completeName">Complete Name of Currency</param>
        public void Edit(string shortName, string completeName)
        {
            ShortName = shortName;
            CompleteName = completeName;
        }
    }
}
