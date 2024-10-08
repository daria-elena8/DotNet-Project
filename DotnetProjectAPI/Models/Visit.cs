﻿using DotnetProjectAPI.Models.Base;

namespace DotnetProjectAPI.Models
{
    public class Visit
    {
        // composed key
        public Guid userId { get; set; }
        public Guid placeId { get; set; }

        public string title { get; set; }
        public string? description { get; set; }
        public int rating { get; set; } = 0;

        // Place - Visit       One-to-Many relation
        // Originated from separating User-Place Many-to-Many relation
        public Place place { get; set; }


        // User - Visit        One-to-Many relation
        // Originated from separating User-Place Many-to-Many relation
        public User user { get; set; }


        // Visit - Like        One-to-Many relation
        public List<Like> likes { get; set; }


        // Visit - Comment     One-to-Many relation
        public List<Comment> comments { get; set; }


        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
        public bool isDeleted { get; set; } = false;

    }
}
