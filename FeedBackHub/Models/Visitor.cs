﻿#nullable disable

namespace FeedBackHub.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }

        public Visitor()
        {
            CreatedDate = DateTime.Now;
        }
    }
}