using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcusDesafio.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateOfSale{ get; set; }
        public int ValueSale { get; set; }
        public bool Active { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
