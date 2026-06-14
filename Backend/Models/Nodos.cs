namespace Backend.Models;

public class Nodos
{
    public int IDNodo { get; set; }

    public enum Lugar
    {
        LaTroncal,
        Cochancay,
        ElTriunfo,
        VirgendeFátima,
        Milagro,
        PanchoNegro,
        PuertoInca,
        Yaguachi,
        UNEMI
    }
    
    public string Descripcion { get; set; }
    
    public ICollection<Aristas> Origen { get; set; } = new List<Aristas>();
    public ICollection<Aristas> Destino { get; set; } = new List<Aristas>();
}