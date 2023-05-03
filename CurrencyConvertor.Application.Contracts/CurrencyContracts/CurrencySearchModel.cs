namespace CurrencyConvertor.Application.Contracts.CurrencyContracts
{
    /// <summary>
    /// Searching by <value>ShortName</value>
    /// </summary>
    public class CurrencySearchModel
    {
        /// <summary>
        /// Short name of currency
        /// </summary>
        public string ShortName { get; set; }
    }
}