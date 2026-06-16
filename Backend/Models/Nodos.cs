namespace Backend.Models;
using System.ComponentModel.DataAnnotations;
public class Nodos
{
    [Key]
    public int IDNodo { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public ICollection<Aristas> Origen { get; set; } = new List<Aristas>();
    public ICollection<Aristas> Destino { get; set; } = new List<Aristas>();
}