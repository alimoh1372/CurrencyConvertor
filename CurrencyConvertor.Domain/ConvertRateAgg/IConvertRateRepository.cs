using _0_Framework.Domain;

namespace CurrencyConvertor.Domain.ConvertRateAgg
{
    /// <summary>
    /// To working with <see cref="ConvertRate"/> in the database
    /// </summary>
    public interface IConvertRateRepository:IBaseRepository<long,ConvertRate>
    {
        
    }
}