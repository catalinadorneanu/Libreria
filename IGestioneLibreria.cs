using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    interface IGestioneLibreria
    {
        void SelectAll();
        void TuttiLibriCartacei();
        void TuttiAudiolibri();
        void ModificaLibri();
        void ModificaAudiolibri();
        void CercaLibroPerTitolo();
        void AggiungiLibro();
    }
}
