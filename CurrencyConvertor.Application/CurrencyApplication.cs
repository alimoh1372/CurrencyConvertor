using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using CurrencyConvertor.Application.Contracts.CurrencyContracts;
using CurrencyConvertor.Domain.CurrencyAgg;

namespace CurrencyConvertor.Application
{
    public class CurrencyApplication : ICurrencyApplication
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyApplication(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public OperationResult Create(CurrencyCreate command)
        {
            OperationResult result = new OperationResult();

            //check if there is any currency with this short name then return failed operation result
            if (_currencyRepository.IsExists(x => x.ShortName == command.ShortName))
                return result.Failed(ApplicationMessage.Duplication);

            //create the new currency
            Currency currency = new Currency(command.ShortName, command.CompleteName);

            //add currency to the currency DbSet 
            _currencyRepository.Create(currency);

            //save all changes on change tracker to the database 
            _currencyRepository.SaveChanges();


            //return the successful message and state to this operation
            return result.Succedded();
        }

        public OperationResult Edit(EditCurrency command)
        {
            OperationResult result = new OperationResult();

            //check if there is any currency with this short name except current entity (x.id!=command.Id)then return failed operation result
            if (_currencyRepository.IsExists(x =>
                    x.ShortName == command.ShortName && 
                    x.Id != command.Id))  return result.Failed(ApplicationMessage.Duplication);

            //find the currency to edit from database
            Currency currency = _currencyRepository.Get(command.Id);

            //check if not found return the operation failed status
            if (currency == null)
                return result.Failed(ApplicationMessage.NotFound);
            
            //edit currency 
            currency.Edit(command.ShortName, command.CompleteName);
                

            //save all changes on change tracker to the database 
            _currencyRepository.SaveChanges();


            //return the successful message and state to this operation
            return result.Succedded();
        }



        public EditCurrency GetDetail(long id)
        {
            return _currencyRepository.GetDetail(id);
        }



        public List<CurrencyViewModel> Search(CurrencySearchModel searchModel)
        {
            return _currencyRepository.Search(searchModel);
        }
    }
}
