using MarianelaVentura_AP1_P2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarianelaVentura_AP1_P2.Models;

public class Combos
{
    [Key]
    public int ComboId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(100, ErrorMessage = "La descripción no puede exceder los 100 caracteres.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El estado de venta es obligatorio.")]
    public bool Vendido { get; set; }

    public ICollection<CombosDetalle>? CombosDetalles { get; set; } = new List<CombosDetalle>();
}