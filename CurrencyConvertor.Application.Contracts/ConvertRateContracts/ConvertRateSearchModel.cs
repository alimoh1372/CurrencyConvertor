namespace CurrencyConvertor.Application.Contracts.ConvertRateContracts
{
    public class ConvertRateSearchModel
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
        public string SourceCurrency { get; set; }




        /// <summary>
        /// use for relation with currency model
        /// </summary>
        public long FkDestinationCurrencyId { get; set; }
        /// <value>
        /// <c>DestinationCurrency</c>
        /// <br/>
        /// shortName of Destination <c>Currency</c>
        /// </value>>
        public string DestinationCurrency { get; set; }
    }
}