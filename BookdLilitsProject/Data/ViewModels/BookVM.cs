using System;
using System.Collections.Generic;

namespace BookdLilitsProject.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public DateTime? DateWrite { get; set; }
        public string CoverUral { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorsIds { get; set; }
    }
}
public class BookWithAuthorsVM
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
    public DateTime? DateRead { get; set; }
    public int? Rate { get; set; }
    public string Genre { get; set; }
    public DateTime? DateWrite { get; set; }
    public string CoverUral { get; set; }

    public string PublisherName { get; set; }
    public List<string> AuthorsNames { get; set; }
}