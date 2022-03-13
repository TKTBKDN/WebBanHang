using System.ComponentModel.DataAnnotations.Schema;

namespace Commerce.Repository.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
