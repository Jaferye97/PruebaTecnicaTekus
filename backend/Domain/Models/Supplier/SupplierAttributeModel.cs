namespace Domain.Models.Supplier
{
    public class SupplierAttributeModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string AttributeName { get; set; } = string.Empty;
        public string AttributeValue { get; set; } = string.Empty;
    }
}
