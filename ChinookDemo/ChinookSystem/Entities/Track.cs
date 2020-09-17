using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
#endregion


namespace ChinookSystem.Entities
{
    [Table("Tracks")]
    internal class Track
    {
        private string _Composer;
        [Key]

        public int TrackId { get; set; }

        [Required(ErrorMessage ="Track Name is required")]
        [StringLength(200,ErrorMessage ="Track Name is limited to 200 characters")]
        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220, ErrorMessage = "Track Composer is limited to 220 characters")]
        public string Composer
        {
            get { return _Composer; }
            set { _Composer = string.IsNullOrEmpty(value) ? null : value; }
        }

        public int Millisecond { get; set; }

        public int? Bytes { get; set; }

        public decimal UnitPrice { get; set; }

        //navigational properties
        // virtually map the relationship of table A to table B
        // use to overlay a model of the database ERD relationships
        //tracks has a relationship to albums mediatype genres, invoicelines, PlaylistTracks
        //A track has one parent(Album)
        //An album has zero, one or more children(Tracks)
        //an entity may has both virtual properties for parent relationships and children relationships
        //Track and MediaTypes (child to parent)
        //Track and Genres(child to parent)
        //Track and InvoiceLines(Parent to child)
        //Track and playlistTrack(parent to children)

        public virtual Album Album { get; set; }
        public virtual MediaType MediaTypes { get; set; }
    }
}
