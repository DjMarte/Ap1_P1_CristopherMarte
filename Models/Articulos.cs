using System.ComponentModel.DataAnnotations;

namespace Ap1_P1_CristopherMarte.Models;

//Precio = (Costo * %)/100 + costo

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [RegularExpression(@"^[a-zA-z\s]+$", ErrorMessage = "Solo se permiten letras")]
    [Required(ErrorMessage = "Descripcion obligatorio")]
    public string? Descripcion { get; set; }

    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten numeros")]
    [Range(0.01, 1000000, ErrorMessage = "Ingrese un valor mayor a 0.01 y menor o igual a 1000000")]
    [Required(ErrorMessage = "Costo obligatorio")]
    public decimal Costo{ get; set; }

    
	[RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten numeros")]
	[Required(ErrorMessage = "Ganancia obligatoria")]
	public decimal Ganancia { get; set; }

	[RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten numeros")]
	[Range(0.01, 1000000, ErrorMessage = "Ingrese un valor mayor a 0.01 y menor o igual a 1000000")]
    [Required(ErrorMessage = "Precio obligatorio")]
    public decimal Precio { get; set; }
}
