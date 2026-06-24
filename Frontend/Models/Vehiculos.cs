namespace Frontend.Models;


public class Vehiculos
{
    public int IDVehiculos { get; set; }

    public string? TipoVehiculo { get; set; } = string.Empty;
    public string? PlacaVehiculo { get; set; } = string.Empty;

    public int CapacidadVehiculo { get; set; }


    public ChoferesAutorizados? ChoferAsignado { get; set; }


    public bool EstadoVehiculo { get; set; }
}