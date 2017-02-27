using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public class Album
    {
        public Album()
        {
            this.Photos = new HashSet<Photo>();
            
        }
        public Guid AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime AlbumDate { get; set; }
        public string Description { get; set; }
        

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
