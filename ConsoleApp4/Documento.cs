using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Documento
    {
        public string Codice { get; set; }
        public string Titolo { get; set; }
        public int Anno { get; set; }
        public string Settore { get; set; }
        public Stato Stato { get; set; }
        public List<Autore> Autori { get; set; }
        public int Scaffale { get; set; }

        public Documento(string codice, string titolo, int anno, string settore, List<Autore> autori)
        {
            Codice = codice;
            Titolo = titolo;
            Settore = settore;
            Autori = new List<Autore>();
            Stato = Stato.Disponibile;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Codice: {Codice}");
            sb.AppendLine($"Titolo: {Titolo}");
            return sb.ToString();
        }
    }
}
