using System;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Models
{
    public class Photo
    {
        public Photo()
        {
            PhotoId = Guid.NewGuid();
        }


        public Guid PhotoId { get; set; }
        public string PhotoName { get; set; }
        
        public DateTime PhotoDate { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public Guid AlbumId { get; set; }
        public virtual Album Album { get; set; }

    }
}
