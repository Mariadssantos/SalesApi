using MarcusDesafio.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarcusDesafio.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public TypeDocClient TypeDoc { get; set; } = (TypeDocClient)0;
        public string Document { get; set; }
        public string Adress { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Active { get; set; }
    }
}
