using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class DbDisconnectedMode : IGestioneLibreria
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

        public void AggiungiLibro()
        {
            throw new NotImplementedException();
        }

        public void CercaLibroPerTitolo()
        {
            throw new NotImplementedException();
        }

        public void ModificaAudiolibri()
        {
            throw new NotImplementedException();
        }

        public void ModificaLibri()
        {
            throw new NotImplementedException();
        }

        public void SelectAll()
        {
            Connection(out SqlConnection connection, out SqlCommand command);
            command.CommandText = "select * from dbo.Libri";

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;

            // Creo una tabella vuota
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Libri");

            foreach (DataRow row in dataSet.Tables["Libri"].Rows)
            {
                var titolo = row["Titolo"];
                var autore = row["Autore"];
                var isbn = row["CodiceISBN"];
                var pagine = row["NumeroPagine"];
                var quantita = row["Quantita"];

                Console.WriteLine($"Titolo: {titolo}, Autore: {autore}, ISBN: {isbn}, Pag: {pagine}, Quantita:{quantita}");
            }

            connection.Close();
        }

        public void TuttiAudiolibri()
        {
            throw new NotImplementedException();
        }

        public void TuttiLibriCartacei()
        {
            throw new NotImplementedException();
        }
    }
}
