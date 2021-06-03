using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class DbConnectedMode:IGestioneLibreria
    {
     
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;" +
            "Initial Catalog = Libreria;" +
            "integrated Security=true;";

   
        public void Connection(out SqlConnection connection, out SqlCommand command)
        {
            
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
        }

        public void SelectAll()
        {
            
            Connection(out SqlConnection connection, out SqlCommand comm);

            comm.CommandText = "SELECT  * from dbo.Audiolibri;";
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                var titolo = reader[0];
                var autore = reader[1];
                var isbn = reader[2];
                var durata = reader[3];
                Console.WriteLine($"{titolo} - {autore} - ISBN: {isbn} - {durata} minuti \n");
            }
            connection.Close();

            Connection(out SqlConnection connessione, out SqlCommand command);

            command.CommandText = " SELECT  * from dbo.Libri ;";
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                var titolo = read[0];
                var autore = read[1];
                var isbn = read[2];
                var pagine = read[3];
                var quantita = read[4];
                Console.WriteLine($"{titolo} - {autore} - ISBN: {isbn} -Pag: {pagine} - Quantità: {quantita} \n");
            }
            connessione.Close();
        }
        public void TuttiLibriCartacei()
        {

            Connection(out SqlConnection connection, out SqlCommand command);
            command.CommandText = " SELECT  * from dbo.Libri ;";
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {

                var titolo = read[0];
                var autore = read[1];
                var isbn = read[2];
                var pagine = read[3];
                var quantita = read[4];
                Console.WriteLine($"{titolo} - {autore} - ISBN: {isbn} - Pag: {pagine} - Quantità: {quantita} \n");
            }

            connection.Close();
        }
        public void TuttiAudiolibri()
        {
      
            Connection(out SqlConnection connection, out SqlCommand comm);
            comm.CommandText = "SELECT  * from dbo.Audiolibri;";
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                var titolo = reader[0];
                var autore = reader[1];
                var isbn = reader[2];
                var durata = reader[3];
                Console.WriteLine($"{titolo} - {autore} - ISBN: {isbn} - {durata} minuti \n");
            }
            connection.Close();
        }
        public void ModificaLibri()
        {
         
            Connection(out SqlConnection connection, out SqlCommand comm);
            TuttiLibriCartacei();


            string isbn;
            do
            {
                Console.WriteLine("Inserisci L'ISBN del libro da modificare");
                isbn = Console.ReadLine();
            } while (isbn.Length != 13);
            int qnt;
            do
            {
                Console.WriteLine("Inserisci quantità desiderata");
            } while (!int.TryParse(Console.ReadLine(), out qnt));

            comm.CommandText = "UPDATE dbo.Libri SET Quantita = @Quantita WHERE CodiceISBN = @CodiceISBN ;";
            comm.Parameters.AddWithValue("@CodiceISBN", isbn);
            comm.Parameters.AddWithValue("@Quantita", qnt);
            comm.ExecuteNonQuery();
            connection.Close();
        }
        public void ModificaAudiolibri()
        {
            Connection(out SqlConnection connection, out SqlCommand comm);
            TuttiAudiolibri();

            string isbn;
            do
            {
                Console.WriteLine("Inserisci L'ISBN del Audiolibro da modificare");
                isbn = Console.ReadLine();
            } while (isbn.Length != 13);
            int dur;
            do
            {
                Console.WriteLine("Inserisci la durata desiderata");
            } while (!int.TryParse(Console.ReadLine(), out dur));

            comm.CommandText = "UPDATE dbo.Audiolibri SET Durata = @Durata WHERE CodiceISBN = @CodiceISBN ;";
            comm.Parameters.AddWithValue("@CodiceISBN", isbn);
            comm.Parameters.AddWithValue("@Durata", dur);
            comm.ExecuteNonQuery();
            connection.Close();
        }
        public void CercaLibroPerTitolo()
        {
            Console.WriteLine("Inserisci il titolo:");
            string titolo = Console.ReadLine();

            Connection(out SqlConnection connection, out SqlCommand comm);
            comm.CommandText = "SELECT * from dbo.Audiolibri where Titolo = @Titolo;";
            comm.Parameters.AddWithValue("@Titolo", titolo);
            SqlDataReader reader = comm.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("Non esiste.Riprova");
            }
            else
            {

                while (reader.Read())
                {

                    var titolo1 = reader[0];
                    var autore = reader[1];
                    var isbn = reader[2];
                    var durata = reader[3];
                    Console.WriteLine($"{titolo1} - {autore} - ISBN: {isbn} - {durata} minuti \n");
                }
            }
            connection.Close();

            Connection(out SqlConnection connessione, out SqlCommand command);
            command.CommandText = "SELECT * from dbo.Libri where Titolo = @Titolo;";
            command.Parameters.AddWithValue("@Titolo", titolo);
  
            SqlDataReader read = command.ExecuteReader();
            if (!read.HasRows)
            {
                Console.WriteLine("Non esiste.Riprova");
            }
            else
            {
                while (read.Read())
                {
                    var titolo2 = read[0];
                    var autore = read[1];
                    var isbn = read[2];
                    var pagine = read[3];
                    var quantita = read[4];
                    Console.WriteLine($"{titolo2} - {autore} - ISBN: {isbn} - Pag: {pagine}. Quantità: {quantita} \n");
                }
            }
            connessione.Close();
        }
        public void AggiungiLibro()
        {
            Connection(out SqlConnection connection, out SqlCommand command);

            
            Console.WriteLine("Vuoi inserire un audiolibro od un libro cartaceo? Inserisci A per audiolibro e L per libro cartaceo");
            string scelta = Console.ReadLine();
            if (scelta.ToUpper() == "L")
            {
                Console.WriteLine("Inserisci titolo: ");
                string titolo = Console.ReadLine();
                Console.WriteLine("Inserisci Autore ");
                string autore = Console.ReadLine();
                string isbn;
                do
                {
                    Console.WriteLine("Inserisci un codice ISBN da 13 caratteri");
                    isbn = Console.ReadLine();
                } while (isbn.Length != 13);
                Console.WriteLine("Inserisci numero pagine del libro ");
                int numeroPagine = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci quantità disponibile ");
                int quantitaInMagazzino = int.Parse(Console.ReadLine());

                command.CommandText = "insert into dbo.Libri values (@Titolo,@Autore, @CodiceISBN, @NumeroPagine, @Quantita)";
                command.Parameters.AddWithValue("@Titolo", titolo);
                command.Parameters.AddWithValue("@Autore", autore);
                command.Parameters.AddWithValue("@CodiceISBN", isbn);
                command.Parameters.AddWithValue("@NumeroPagine", numeroPagine);
                command.Parameters.AddWithValue("@Quantita", quantitaInMagazzino);

                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                Console.WriteLine("Inserisci titolo: ");
                string titolo = Console.ReadLine();
                Console.WriteLine("Inserisci Autore ");
                string autore = Console.ReadLine();
                string isbn;
                do
                {
                    Console.WriteLine("Inserisci un codice ISBN da 13 caratteri");
                    isbn = Console.ReadLine();
                } while (isbn.Length != 13);
                Console.WriteLine("Inserisci la durata dell'audiolibro ");
                int durata = int.Parse(Console.ReadLine());
               
                command.CommandText = "insert into dbo.Audiolibri values (@Titolo,@Autore, @CodiceISBN, @durata)";
                command.Parameters.AddWithValue("@Titolo", titolo);
                command.Parameters.AddWithValue("@Autore", autore);
                command.Parameters.AddWithValue("@CodiceISBN", isbn);
                command.Parameters.AddWithValue("@Durata", durata);
             

                command.ExecuteNonQuery();
                connection.Close();

            }

    }

     

        

        
        

        
    }
}
