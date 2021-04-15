using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Libro : Documento
    {
        public int NumeroPagine { get; set; }
        public Libro(string isbn, string titolo, int anno, string settore, List<Autore> autori, int numeroPagine) 
            : base(isbn, titolo, anno, settore, autori)
        {
            NumeroPagine = numeroPagine;
        }
    }
}
