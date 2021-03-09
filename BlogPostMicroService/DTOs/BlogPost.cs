﻿using System;

namespace BlogPostMicroService.DTOs
{
    [Serializable]
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
    }
}
