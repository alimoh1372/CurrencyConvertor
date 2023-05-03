namespace CurrencyConvertor.Application.Contracts.CurrencyContracts
{
    public class CurrencyViewModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Short name of currency
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Complete name of Currency
        /// </summary>
        public string CompleteName { get; set; }
    }
}