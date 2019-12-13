using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class ManNoticeBoard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string MesBody { get; set; }
        public bool Seen { get; set; } = false;

        public List<Links> links = new List<Links>();
    }
}