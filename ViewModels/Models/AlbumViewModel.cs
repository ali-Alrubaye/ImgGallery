using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            this.PhotoAlbV = new HashSet<PhotoViewModel>();
            
        }

        public Guid AlbumId { get; set; }
        [Required]
        public string AlbumName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AlbumDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PhotoViewModel> PhotoAlbV { get; set; }
    }
}