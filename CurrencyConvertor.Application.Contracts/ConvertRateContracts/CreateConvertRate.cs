namespace CurrencyConvertor.Application.Contracts.ConvertRateContracts
{
    public class CreateConvertRate
    {
        /// <summary>
        /// foreign key to relation with currency table
        /// </summary>
        public long FkSourceCurrencyId { get; set; }

        /// <value>
        /// <c>SourceCurrency</c>
        /// <br/>
        ///  short name of source <c>Currency</c>
        /// </value>>
        public string SourceCurrency { get;  set; }
        /// <summary>
        /// use for relation with currency model
        /// </summary>
        public long FkDestinationCurrencyId { get;  set; }
        /// <value>
        /// <c>DestinationCurrency</c>
        /// <br/>
        /// shortName of Destination <c>Currency</c>
        /// </value>>
        public string DestinationCurrency { get;  set; }
        /// <value>
        /// <c>RateFromSourceToDestination</c>
        /// <br/>
        /// نرخ تبدیل پول از واحد مبدا به واحد مقصد را نگهداری میکند
        /// </value>>
        public double RateFromSourceToDestination { get;  set; }



        /// <summary>
        /// represent the status of active or deActive of this record
        /// </summary>
        public bool IsActive { get;  set; }

    }
}