namespace Backend.Models;
using System.ComponentModel.DataAnnotations;
public class Nodos
{
    [Key]
    public int IDNodo { get; set; }
    public string Lugar { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public double Latitud { get; set; }

    public double Longitud { get; set; }
    public ICollection<Aristas> Origen { get; set; } = new List<Aristas>();
    public ICollection<Aristas> Destino { get; set; } = new List<Aristas>();
}