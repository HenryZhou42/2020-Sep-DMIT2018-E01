using ChinookSystem.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using ChinookSystem.Entities;

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        #region Queries
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
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public AlbumItem Album_FindByID( int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                var results = (from k in context.Albums
                              where k.AlbumId == albumid
                              select new AlbumItem()
                              {
                                  Title = k.Title,
                                  ReleaseYear = k.ReleaseYear,
                                  ReleaseLabel = k.ReleaseLabel,
                                  AlbumId = k.AlbumId,
                                  ArtistId = k.ArtistId
                              }).FirstOrDefault();
                return results;
            }
        }
        #endregion
        #region CRUD: Add, Update and Delete
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void Album_Add(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                Album newItem = new Album
                {
                    //pkey is identity, not needed
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseLabel = item.ReleaseLabel,
                    ReleaseYear = item.ReleaseYear
                };
                context.Albums.Add(newItem);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Album_Update(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                Album newItem = new Album
                {
                    //pkey is identity, not needed
                    AlbumId = item.AlbumId,
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseLabel = item.ReleaseLabel,
                    ReleaseYear = item.ReleaseYear
                };
                context.Entry(newItem).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete,false)]
        public void Album_Delete(AlbumItem item)
        {
            Album_Delete(item.AlbumId);
        }
        public void Album_Delete(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                var exists = context.Albums.Find(albumid);
                context.Albums.Remove(exists);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
