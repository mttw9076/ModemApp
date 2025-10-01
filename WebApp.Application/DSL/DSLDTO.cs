using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.DSL
{
    public class DSLDTO
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
    
    }
}
    

