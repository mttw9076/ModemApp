using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain.Entities
{
    public class DSL
    {
        [Key]
        public int Id { get; set; }
        public int ShopId { get; set; } = default!;
        
        public string? ServiceName { get; set; } = default!;
        public string? ServiceType { get; set; } = default!;
        public string? IP { get; set; } = default!;
        public string? Mask { get; set; } = default!;
        public string? Gateway { get; set; } = default!;
        public string? DNS1 { get; set; } = default!;
        public string? DNS2 { get; set; } = default!;
        public string? Login { get; set; } = default!;
        public string? Password { get; set; } = default!;
        public string? Description { get; set; } = default!;

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? ModifiedById { get; set; }
        public IdentityUser? ModifiedByUser { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
