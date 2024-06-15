using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace curso_linq
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public LinqQueries() 
        { 
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
            }
        }

        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }
    }
}
