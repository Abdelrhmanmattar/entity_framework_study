namespace entity_fr2.entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {OrderId} ({ProductId}) {Quantity} {UnitPrice}";
        }
    }

}
