using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarianelaVentura_AP1_P2.Models;

public class CombosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "El ComboId es obligatorio.")]
    public int ComboId { get; set; }

    [ForeignKey("ComboId")]
    public Combos? Combo { get; set; }

    [Required(ErrorMessage = "El ArticuloId es obligatorio.")]
    public int ArticuloId { get; set; }

    [ForeignKey("ArticuloId")]
    public Articulos? Articulo { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El costo es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser un valor positivo.")]
    public decimal Costo { get; set; }
}
