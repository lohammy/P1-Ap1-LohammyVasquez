
using System.ComponentModel.DataAnnotations;

namespace P1_Ap1_LohammyVasquez.Models;


public class Registro
{
    [Key]
    public int id { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]

    public string name { get; set; }
}

