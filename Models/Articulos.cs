﻿using System.ComponentModel.DataAnnotations;

namespace MarianelaVentura_AP1_P2.Models
{
    public class Articulos
    {
        [Key]

        [Required(ErrorMessage = "El Id debe de ser mayor a 1")]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "Este Campo debe de ser obligatorio")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este Campo debe de ser obligatorio")]
        public decimal Costo { get; set; }


        [Required(ErrorMessage = "Este Campo debe de ser obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Este Campo debe de ser obligatorio")]
        public int Existencia { get; set; }

    }
}
