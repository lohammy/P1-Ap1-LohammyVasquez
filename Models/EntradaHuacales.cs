
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using P1_Ap1_LohammyVasquez.DAL;
using P1_Ap1_LohammyVasquez.Models;

namespace P1_Ap1_LohammyVasquez.Models;


public class EntradaHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "En este campo solo se permiten letras. ")]
    public string NombreCliente { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    public decimal Importe { get; set; } 

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Range(1, double.MaxValue, ErrorMessage = "Debe introducir una cantidad valida")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Range(1, double.MaxValue, ErrorMessage = "Debe introducir un monto valido")]
    public decimal Precio { get; set; }
}

