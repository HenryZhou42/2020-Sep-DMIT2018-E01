using ChinookSystem.DAL;
using ChinookSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.BLL
{
    public class AlbumController
    {
        public List<AlbumArtist> Album_FindByArtist(int artiistid)
        {
            using (var context = new ChinookSystemContext())
            {
                var results = from k in context.Albums
                              where k.ArtistId == artiistid
                              select new AlbumArtist()
                              {
                                  Title = k.Title,
                                  ReleaseYear = k.ReleaseYear,
                                  ReleaseLabel = k.ReleaseLabel,
                                  AlbumId = k.AlbumId,
                                  ArtistId = k.ArtistId
                              };
                return results.ToList();
            }
        }
    }
}
