using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                // .Include -> Eager loading
                // using virtual -> lazy loading

                var comicBooks = context.ComicBooks
                    //.Include(cb => cb.Series)
                    //.Include(cb => cb.Artists.Select(a => a.Artist))
                    //.Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();
                foreach (var comicBook in comicBooks)
                {
                    // Explicit loading
                    if (comicBook.Series == null)
                    {
                        context.Entry(comicBook)
                            .Reference(cb => cb.Series)
                            .Load();
                    }
                    var artistRoleNames = comicBook.Artists
                        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artistsRolesDisplayText = string.Join(", ", artistRoleNames);

                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistsRolesDisplayText);
                }

                Console.ReadLine();
            }
        }
    }
}
