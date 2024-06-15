using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso_linq
{
    public class Book
    {
        private string Title {get; set;}

        private int PageCount {get; set;}

        private DateTime PublishedDate {get; set;}

        private string ThumbnailUrl {get; set;}

        private string ShortDescription {get; set;}

        private status Status {get; set;}

        private string[] Authors {get; set;}

        private string[] Categories {get; set;}


    }

    public enum status
    {
        PUBLISH,
        UNPUBLISH,
    }
}
