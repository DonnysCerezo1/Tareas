namespace Backend.DTO;


public class AristaDto
{
    public int IDAristas { get; set; }

    public string Origen { get; set; } = "";

    public string Destino { get; set; } = "";

    public double Costo { get; set; }

    public double Distancia { get; set; }
}