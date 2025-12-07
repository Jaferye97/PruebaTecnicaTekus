namespace Domain.Models.Service
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
    }
}
