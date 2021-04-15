using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class DVD : Documento
    {
        public int Durata { get; set; }
        public DVD(string seriale, string titolo, int anno, string settore, List<Autore> autori, int durata)
            : base(seriale, titolo, anno, settore, autori)
        {
            Durata = durata;
        }
    }
}
