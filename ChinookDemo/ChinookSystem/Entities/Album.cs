﻿using System;
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
    [Table("Albums")]
    internal class Album
    {
        private string _ReleaseLabel;
        [Key]
        public int AlbumId { get; set; }
        [Required(ErrorMessage = "Album title is required")]
        [StringLength(160, ErrorMessage = "Length is limited to 160 characters")]
        public string Title { get; set; }

        //[ForeignKey] DO NOT USE!!!!!!!!!!!!!!!!

        public int ArtistId { get; set; }

        //[Range(1950, 3000)]
        public int ReleaseYear { get; set; }

        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set { _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value; }
        }
    }
}