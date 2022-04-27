﻿using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Book
    {
        [Key]
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
