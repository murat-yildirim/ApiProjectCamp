﻿namespace ApiProjectCamp.WebApi.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public int? CategoryId { get; set; } //her ürünün bir categorisi olsun (?) ama olmasada hata vermesin
        public Category Category { get; set; }

    }
}
