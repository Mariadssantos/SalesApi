using MarcusDesafio.Data;
using MarcusDesafio.Helpers;
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

        //criar outra função p validar o cadastro da venda no tempo ✔
        public async Task<bool> verifySale(Sales sales)
        {
            var verifyClient = _context.Clients.Where(x => x.Id == sales.ClientId);
            var minutesSale = sales.DateOfSale.Value.Minute;
            var verifySale = _context.Sales.Where(x => x.ValueSale == sales.ValueSale && minutesSale > DateTime.Now.Minute);
            if (verifyClient == null && verifySale == null)
                return false;
            return true;
        }
    }
}