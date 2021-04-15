using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Utente : Persona
    {
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Utente(string nome, string cognome, string telefono, string email, string password) : base(nome, cognome)
        {
            Telefono = telefono;
            Email = email;
            Password = password;
        }

    }
}
