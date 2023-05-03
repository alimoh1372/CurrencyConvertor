using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using CurrencyConvertor.Application.Contracts.CurrencyContracts;

namespace CurrencyConvertor.Domain.CurrencyAgg
{
    /// <summary>
    /// To working with the Currency entity such as CRUD operates
    /// </summary>
    public interface ICurrencyRepository : IBaseRepository<long, Currency>
    {
        /// <summary>
        /// Get a <see cref="EditCurrency"/> by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>if there is an entity with <paramref name="id"/> return it else return <see langword="null"/></returns>
        EditCurrency GetDetail(long id);



        /// <summary>
        /// To search  the by search model
        /// </summary>
        /// <param name="searchModel">items we want to search by it</param>
        /// <returns>list of containing search model</returns>
        List<CurrencyViewModel> Search(CurrencySearchModel searchModel);
    }
}
