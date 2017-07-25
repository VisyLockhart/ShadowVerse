using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ShadowVerse.Models
{
    [MetadataType(typeof(SpellMetaData))]
    public partial class Spell
    {
    }
    public partial class SpellMetaData
    {
        public int id { get; set; }
        public string story { get; set; }
        public string ability { get; set; }
        public string imgUrl { get; set; }
        [StringLength(1,ErrorMessage ="只能是一個Char")]
        public string enhance { get; set; }
    }
}