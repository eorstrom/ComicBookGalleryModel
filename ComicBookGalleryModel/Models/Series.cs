using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class Series
    {
        public Series()
        {
            ComicBook = new List<ComicBook>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string MyProperty { get; set; }

        public ICollection<ComicBook> ComicBooks { get; set; }
        public List<ComicBook> ComicBook { get; private set; }
    }
}
