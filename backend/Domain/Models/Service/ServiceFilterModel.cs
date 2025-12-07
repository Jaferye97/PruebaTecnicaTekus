using Domain.Models.Commons;

namespace Domain.Models.Service
{
    public class ServiceFilterModel : FilterModel
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal MinHourlyRate { get; set; }
        public decimal MaxHourlyRate { get; set; }
    }
}
