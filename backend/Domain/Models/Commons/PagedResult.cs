using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.Commons
{
    [ExcludeFromCodeCoverage]
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
