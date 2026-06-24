namespace Frontend.Models;

public class Nodos
{
    public int IDNodo { get; set; }

    public string Lugar { get; set; } = "";

    public string Descripcion { get; set; } = "";

    public double Latitud { get; set; }

    public double Longitud { get; set; }
}