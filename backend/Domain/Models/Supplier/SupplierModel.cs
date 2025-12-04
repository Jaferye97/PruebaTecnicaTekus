using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.Supplier
{
    [ExcludeFromCodeCoverage]
    public class SupplierModel
    {
        public int Id { get; set; }
        public string TaxId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IList<SupplierAttributeModel> SupplierAttribute { get; set; } = new List<SupplierAttributeModel>();
    }
}
