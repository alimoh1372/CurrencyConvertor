namespace CurrencyConvertor.Domain.ConvertRateAgg
{
    /// <summary>
    /// To working with <see cref="ConvertRate"/>
    /// </summary>
    public interface IConvertRateRepository
    {
        /// <summary>
        /// Create the <see cref="ConvertRate"/>
        /// </summary>
        /// <param name="command"></param>
        void Create(ConvertRate command);
    }
}