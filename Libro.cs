using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
   abstract class Libro
    {
        //I libri hanno titolo - autore - codice ISBN -> abstract

        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string CodiceISBN { get; set; }
        


        public Libro(string titolo, string autore, string codiceISBN)
        {
            Titolo = titolo;
            Autore = autore;
            CodiceISBN = codiceISBN;
            
        }

        public Libro()
        {

        }

        public string StampaLibro()
        {
            return $"\nCodice ISBN {CodiceISBN} - Titolo:{Titolo}, Autore: {Autore} ";
        }
    }
    //enum TipologiaLibro
    //{
    //    Audiolibro,
    //    Cartaceo
    //}
}
