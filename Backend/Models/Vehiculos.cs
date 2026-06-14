using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Vehiculos
{
    public int IDVehiculos { get; set; }
    
    public string TipoVehiculo { get; set; }
    public string PlacaVehiculo { get; set; }
    public int CapacidadVehiculo { get; set; }
    
    [Column("ChoferAsignado")]
    public int ChoferAsignadoId { get; set; }
    [ForeignKey("ChoferAsignadoId")]
    public ChoferesAutorizados ChoferAsignado { get; set; }
    public bool EstadoVehiculo { get; set; }
    
    
}