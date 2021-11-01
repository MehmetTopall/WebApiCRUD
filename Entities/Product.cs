using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Product:IEntity
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        public string ProductDetail { get; set; }
        [Required]
        public double ProductPrice { get; set; }
    }
}
