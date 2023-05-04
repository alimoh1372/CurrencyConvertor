using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvertor.Application.Contracts.CurrencyContracts
{
    public interface ICurrencyApplication
    {

        /// <summary>
        /// To Create a Currency using <see cref="CurrencyCreate"/>
        /// </summary>
        /// <param name="command">New currency create with <paramref name="command"/></param>
        /// <returns></returns>
        OperationResult Create(CurrencyCreate command);


        /// <summary>
        /// Edit currency entity to <paramref name="command"/>
        /// </summary>
        /// <param name="command">The current Currency change to <paramref name="command"/></param>
        /// <returns></returns>
        OperationResult Edit(EditCurrency command);


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

        long GetIdBy(string currencyShortName);
    }
}
