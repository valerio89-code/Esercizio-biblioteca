using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Prestito
    {
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public Utente Utente { get; set; }
        public Documento Documento { get; set; }
        public Prestito(int durata, Utente utente, Documento documento)
        {
            Inizio = DateTime.Now;
            Fine = DateTime.Now.AddDays(durata);
            Utente = utente;
            Documento = documento;
        }
    }
}
