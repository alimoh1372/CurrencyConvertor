namespace CurrencyConvertor.Application.Contracts.CurrencyContracts
{
    public class CurrencyCreate
    {
        /// <summary>
        /// Short name of currency
        /// </summary>
        public string ShortName { get;  set; }

        /// <summary>
        /// Complete name of Currency
        /// </summary>
        public string CompleteName { get;  set; }
    }
}