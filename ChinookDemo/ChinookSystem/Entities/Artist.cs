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
    //annotate your entity to link to the sql table indicate primary key and key type include validation on fields
    [Table("Artists")]
    internal class Artist
    {

        //private data members
        private string _Name;
        //properties
        //each sql table attributes will be mapped within this entity definition
        //annotation may be needed so some of the properties
        //ANY property annotation MUST appear prior to thhe property

        //[Key] primary key
        //an additional option within this annotation is DatabaseGenerated()
        //by default if no DatabaseGenerate option is given, the primary key
        // is assumed to be an Identity sql primary key
        // Indentity pKey: [Key] or
        //                 [Key， DataBaseGenerated(DatabaseGeneratedOption.Identity)]
        //user pkey: [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //there is a third option for DatabaseGenerated() and that is. Computed
        //this is version of the annotation is used for sql attribute which are computed fields.

        //Compound primary keys
        //[Key, Column(Order=1)]
        //property
        //[Key, Column(Order=2)]
        //property
        //[Key, Column(Order=3)]
        //property

        [Key]
        public int ArtistId { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name
        {
            get { return _Name; }
            set { _Name = string.IsNullOrEmpty(value) ? null : value; }

        }

        public virtual ICollection<Album> Albums { get; set; }
        

        //constructors

        //behaviours
    }
}
