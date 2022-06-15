using MarcusDesafio.Data;
using MarcusDesafio.Models;

namespace MarcusDesafio.Services
{
    public class SaleServices
    {
        private readonly dbContext _context;
        public SaleServices(dbContext context)
        {
            _context = context;
        }

        //criar outra função p validar o cadastro da venda no tempo
        public async Task<bool> verifySale(Sales sales)
        {
            var result = _context.Sales.Where(x => x.ValueSale == sales.ValueSale && sales.DateOfSale == DateTime.Now);
            if (result.Any())
                return false;
            return true;
        }
    }
}
