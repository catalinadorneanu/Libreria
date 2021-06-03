using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class LibroCartaceo: Libro
    {
        //I libri cartacei hanno il numero di pagine e la quantità in magazzino
        public int NumPagine { get; set; }
        public int Quantita { get; set; }

        public LibroCartaceo(string titolo, string autore, string codiceISBN, int numPagine, int quantita)
            :base (titolo, autore, codiceISBN)
        {
            NumPagine = numPagine;
            Quantita = quantita;
        }
        public LibroCartaceo()
        {

        }

        public string StampaLibroCartaceo()
        {
            return $"\nCodice ISBN {CodiceISBN}- Titolo:{Titolo}, Autore: {Autore}, Numero pagine: {NumPagine}, Quantita disponibile: {Quantita}";
        }
    }
}
