using System.Collections.Generic;

namespace BookdLilitsProject.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation Propeties
        public List<Book> Books { get; set; }
    }
}
