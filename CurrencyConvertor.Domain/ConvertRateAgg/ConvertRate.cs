﻿using _0_Framework.Domain;
using CurrencyConvertor.Domain.CurrencyAgg;

namespace CurrencyConvertor.Domain.ConvertRateAgg
{
    /// <summary>
    /// نرخ  تبدیل واحد پول از پول مبدا به پول مقصد را نگهداری میکند
    /// </summary>
    public class ConvertRate : EntityBase
    {
        /// <summary>
        /// foreign key to relation with currency table
        /// </summary>
        public long FkSourceCurrencyId { get; private set; }

        /// <value>
        /// <c>SourceCurrency</c>
        /// <br/>
        ///  واحد پول مبدا را نگهداری میکند
        /// </value>>
        public Currency SourceCurrency { get; private set; }
        /// <summary>
        /// use for relation with currency model
        /// </summary>
        public long FkDestinationCurrencyId { get; private set; }
        /// <value>
        /// <c>DestinationCurrency</c>
        /// <br/>
        /// نام واحد پول مقصد را نگهداری میکند
        /// </value>>
        public Currency DestinationCurrency { get; private set; }
        /// <value>
        /// <c>RateFromSourceToDestination</c>
        /// <br/>
        /// نرخ تبدیل پول از واحد مبدا به واحد مقصد را نگهداری میکند
        /// </value>>
        public double RateFromSourceToDestination { get; private set; }

        /// <summary>
        /// Create the <see cref="ConvertRate"/> object
        /// <remarks> just with this way we can make the objects</remarks>
        /// </summary>
        /// <param name="fkSourceCurrencyId"></param>
        /// <param name="fkDestinationCurrencyId"></param>
        /// <param name="rateFromSourceToDestination"></param>
        public ConvertRate(long fkSourceCurrencyId, long fkDestinationCurrencyId, double rateFromSourceToDestination)
        {
            FkSourceCurrencyId = fkSourceCurrencyId;
            FkDestinationCurrencyId = fkDestinationCurrencyId;
            RateFromSourceToDestination = rateFromSourceToDestination;
        }
    }
}