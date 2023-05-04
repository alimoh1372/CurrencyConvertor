using System.Collections.Generic;
using _0_Framework.Domain;
using CurrencyConvertor.Application.Contracts.ConvertRateContracts;

namespace CurrencyConvertor.Domain.ConvertRateAgg
{
    /// <summary>
    /// To working with <see cref="ConvertRate"/> in the database
    /// <b/>
    /// and create map to using format
    /// </summary>
    public interface IConvertRateRepository:IBaseRepository<long,ConvertRate>
    {

        /// <summary>
        /// To get The record with this <paramref name="id"/> and map it to <see cref="EditConvertRate"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="EditConvertRate"/> of <c>ConvertRate</c></returns>
        EditConvertRate GetDetails(long id);

        /// <summary>
        /// To search in the Convert Rate collection with <paramref name="searchModel"/> Items
        /// </summary>
        /// <param name="searchModel">items we want to search by</param>
        /// <returns></returns>
        List<ConvertRateViewModel> Search(ConvertRateSearchModel searchModel);


        /// <summary>
        /// Clear All Items in ConvertRates
        /// </summary>
        void Clear();



        /// <summary>
        /// Get rate with <paramref name="originCurrency"/> and <paramref name="destinationCurrency"/>
        /// </summary>
        /// <param name="originCurrency"></param>
        /// <param name="destinationCurrency"></param>
        /// <returns>
        /// if there is any <c>ConvertRate</c> to this desired currency return it else return <see langword="false"/>
        /// </returns>
        EditConvertRate GetConvertRateBy(string originCurrency, string destinationCurrency);
    }
}