namespace CurrencyConvertor.Domain.ConvertRateAgg
{
    /// <summary>
    /// نرخ  تبدیل واحد پول از پول مبدا به پول مقصد را نگهداری میکند
    /// </summary>
    public class ConvertRate
    {
       /// <value>
       /// <c>SourceCurrency</c>
       /// <br/>
       /// نام واحد پول مبدا را نگهداری میکند
       /// </value>>
        public string SourceCurrency { get; private set; }


        /// <value>
        /// <c>DestinationCurrency</c>
        /// <br/>
        /// نام واحد پول مقصد را نگهداری میکند
        /// </value>>
        public string DestinationCurrency { get; private set; }
        /// <value>
        /// <c>RateFromSourceToDestination</c>
        /// <br/>
        /// نرخ تبدیل پول از واحد مبدا به واحد مقصد را نگهداری میکند
        /// </value>>
        public double RateFromSourceToDestination { get; private set; }

        /// <summary>
        /// ایجاد یک نرخ تبدیل
        /// </summary>
        /// <param name="sourceCurrency"><see cref="SourceCurrency"/>نام واحد پول مبدا از نوع <see langword="string"/> </param>
        /// <param name="destinationCurrency"><see cref="DestinationCurrency"/>نام واحد پول مقصداز نوع <see langword="string"/> </param>
        /// <param name="rateFromSourceToDestination"><see cref="RateFromSourceToDestination"/>نرخ تبدیل از <paramref name="sourceCurrency"/> به واحد پول مقصد<paramref name="destinationCurrency"/></param>
        public ConvertRate(string sourceCurrency, string destinationCurrency, double rateFromSourceToDestination)
        {
            SourceCurrency = sourceCurrency;
            DestinationCurrency = destinationCurrency;
            RateFromSourceToDestination = rateFromSourceToDestination;
        }

    }
}