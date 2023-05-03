using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using CurrencyConvertor.Application.Contracts.CurrencyContracts;
using CurrencyConvertor.Domain.CurrencyAgg;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConvertor.Infrastructure.EfCore.Repositories
{
    public class CurrencyRepository : BaseRepository<long, Currency>, ICurrencyRepository
    {
        private readonly CurrencyContext _context;
        public CurrencyRepository(CurrencyContext context) : base(context)
        {
            _context = context;
        }


        
        public EditCurrency GetDetail(long id)
        {
            //find  currency by id and  do projection of it to EditCurrency
            EditCurrency editCurrency = _context.Currencies.Select(x => new EditCurrency
            {
                ShortName = x.ShortName,
                CompleteName = x.CompleteName,
                Id = x.Id
            }).FirstOrDefault(x=>x.Id==id);


            return editCurrency;
        }

        public List<CurrencyViewModel> Search(CurrencySearchModel searchModel)
        {
            //Make a query to search in currencies and do projection of it
            var query = _context.Currencies.Select(x => new CurrencyViewModel
            {
                ShortName = x.ShortName,
                CompleteName = x.CompleteName,
                Id = x.Id
            });

            //check if short model isn't empty or null then search the given short name in currencies
            if (!string.IsNullOrWhiteSpace(searchModel.ShortName))
                query = query.Where(x => x.ShortName.ToUpper().Contains(x.ShortName));

            //after make filters return rest of entities
            return query.ToList();

        }
    }
}
