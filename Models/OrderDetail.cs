
namespace DROD.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public virtual Items Items { get; set; }

        public virtual Orders Order { get; set; }
    }
}
