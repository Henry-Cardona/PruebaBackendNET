using System.ComponentModel.DataAnnotations;

namespace MarcasAutosAPI.Models
{
    public class MarcaAuto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
    }
}
