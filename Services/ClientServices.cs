using MarcusDesafio.Data;
using MarcusDesafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarcusDesafio.Services
{
    public class ClientServices
    {
        private readonly dbContext _context;
        public ClientServices(dbContext context)
        {
            _context = context;
        }
        //validar o cpf 
        public async Task<bool> validateCpf(Client client)
        {
            var result = _context.Clients.Where(x => x.Document.Contains(client.Document));
            if (result.Any())
                return false;
            return true;
        }

    }
}
