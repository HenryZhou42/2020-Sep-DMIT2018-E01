using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Dynamic;
#endregion

namespace ChinookSystem.Entities
{
    [Table("MediaTypes")]
    internal class MediaType
    {
        [Key]
        public int MediaTypeId { get; set; }

        
        [StringLength(120, ErrorMessage = "MediaTyoe Name is limited to 200 characters")]
        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
