using MarcusDesafio.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarcusDesafio.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TypeUserDescription TypeUser { get; set; } = (TypeUserDescription)0;
        public DateTime DateRegister { get; set; }
    }
}
