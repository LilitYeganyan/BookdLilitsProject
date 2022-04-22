using System.Collections.Generic;

namespace BookdLilitsProject.Data.ViewModels
{
    public class AuthorVM
    { 
        public string FullName { get; set; }

    }

    public class AuthorWithBooksVM
    { 
      public string FillName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
