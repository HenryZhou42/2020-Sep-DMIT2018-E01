﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    public class AlbumItem
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }
        public int AlbumId { get; set; }

        
        public int ArtistId { get; set; }
    }
}
