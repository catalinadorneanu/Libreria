using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class Audiolibro: Libro
    {
        // Gli audiolibri hanno anche la durata in minuti
        public int Durata { get; set; }

        public Audiolibro(string titolo, string autore, string codiceISBN, int durata)
             :base(titolo, autore, codiceISBN)
        {
            Durata=durata;
        }

        public Audiolibro()
        {

        }

        public string StampaAudiolibro()
        {
            return $"\nCodice ISBN {CodiceISBN} - Titolo:{Titolo}, Autore: {Autore}, Durata: {Durata}";
        }
    }
}

