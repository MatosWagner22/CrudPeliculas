using System.ComponentModel.DataAnnotations;

namespace PruebaWEB.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede superar los 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El director es obligatorio.")]
        [StringLength(100, ErrorMessage = "El director no puede superar los 100 caracteres.")]
        public string Director { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe indicar si es estreno.")]
        public bool EsEstreno { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        public string Genero { get; set; }

        public bool EsAnimada { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de estreno es obligatoria.")]
        public DateTime FechaEstreno { get; set; }

        [Url(ErrorMessage = "Debe ser una URL válida.")]
        [Required(ErrorMessage = "La URL del video es obligatoria.")]
        public string UrlVideo
        {
            get; set;
        }

    }
}
