using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace CurrencyConvertor.Application.Contracts.ConvertRateContracts
{
    /// <summary>
    /// The layer that presentation use
    /// </summary>
    public interface IConvertRateApplication
    {
        /// <summary>
        /// To create the <c>ConvertRate </c>
        /// and reverse convertRate in it
        /// </summary>
        /// <param name="command">needed item to create convert rate</param>
        /// <returns>if operation operate successfully return <see cref="OperationResult.IsSucceded"/> equals <see langword="true"/>
        /// else <see langword="false"/>
        /// </returns>
        OperationResult Create(CreateConvertRate command);

        /// <summary>
        /// Edit The <c>ConvertRate</c> with <paramref name="command"/> items
        /// and edit revers convertRate in it
        /// </summary>
        /// <param name="command">Editable values of <c>ConvertRate</c></param>
        /// <returns>if operation operate successfully return <see cref="OperationResult.IsSucceded"/> equals <see langword="true"/>
        /// else <see langword="false"/>
        /// </returns>
        OperationResult Edit(EditConvertRate command);
        /// <summary>
        /// Active the record with <paramref name="id"/>to show in results
        /// </summary>
        /// <param name="id">represent the id of record we want to active</param>
        /// <returns>if operation operate successfully return <see cref="OperationResult"/>.<c>IsSuccedded</c> equals <see langword="true"/>
        /// else <see langword="false"/>
        /// </returns>
        OperationResult Active(long id);

        /// <summary>
        /// DeActive the record with this <paramref name="id"/>to don't show in results
        /// </summary>
        /// <param name="id">represent the id of record we want to DeActive</param>
        /// <returns>if operation operate successfully return <see cref="OperationResult"/>.<c>IsSuccedded</c> equals <see langword="true"/>
        /// else <see langword="false"/>
        /// </returns>
        OperationResult DeActive(long id);

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

        void Clear();
        EditConvertRate GetConvertRateBy(string originCurrency, string destinationCurrency);
    }
}
