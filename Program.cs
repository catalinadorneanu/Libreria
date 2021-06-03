using System;

namespace Libreria
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creare un programma per la gestione di libri da parte del proprietario del sito
            // I libri hanno titolo - autore - codice ISBN -> abstract
            // Gli audiolibri hanno anche la durata in minuti
            // I libri cartacei hanno il numero di pagine e la quantità in magazzino
            // due libri sono uguali se hanno lo stesso ISBN( cartecei e audiolibri NON hanno lo stesso ISBN)

            // Il proprietario può vedere tutti i libri stampando titolo, autore e se è o no audiolibro
            // vedere tutta la lista di libri cartacei
            // vedere tutta la lista di audiolibri
            // Modificare la quantità di libri cartacei in magazzino
            // Modificare la durata in minuti di un audiolibro
            // Se inserisce un titolo gli viene mostrato sia il libro cartaceo che l'audiolibro
            // Se inserisce un nuovo libro cartaceo o audiolibro, 
            //     prima di inserirlo verificare che non sia già presente tramite codice ISBN)

            //  Gestire il db sia in connected mode che in disconnected mode


            IGestioneLibreria libreria = new DbConnectedMode();
            Console.WriteLine("--- BENVENUTO NELLA TUA LIBRERIA ---");
            do
            {
                Console.WriteLine("\n------ Menu ------");
                Console.WriteLine("Premi 1 - Visualizza tutti i libri");
                Console.WriteLine("Premi 2 - Visualizza i libri cartacei");
                Console.WriteLine("Premi 3 - Visualizza gli audiolibri");
                Console.WriteLine("Premi 4 - Modifica la quantità di libri cartacei");
                Console.WriteLine("Premi 5 - Modifica la durata di un audiolibro");
                Console.WriteLine("Premi 6 - Cerca per titolo");
                Console.WriteLine("Premi 7 - Inserisci un nuovo libro o audiolibro");
                Console.WriteLine("Premi 0 - Exit");

                int scelta;
                do
                {
                    Console.Write("\nFai la tua scelta: ");
                } while (!int.TryParse(Console.ReadLine(), out scelta));

                switch (scelta)
                {
                    case 0:
                        return;
                    case 1:
                        libreria.SelectAll();
                        break;
                    case 2:
                        libreria.TuttiLibriCartacei();
                        break;
                    case 3:
                        libreria.TuttiAudiolibri();
                        break;
                    case 4:
                        libreria.ModificaLibri();
                        break;
                    case 5:
                        libreria.ModificaAudiolibri();
                        break;
                    case 6:
                        libreria.CercaLibroPerTitolo();
                        break;
                    case 7:
                        libreria.AggiungiLibro();
                        break;
                }

            } while (true);



        }
    }
}
