using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Vehiculos
{
    [Key]
    public int IDVehiculos { get; set; }

    public string TipoVehiculo { get; set; } = string.Empty;

    public string PlacaVehiculo { get; set; } = string.Empty;

    public int CapacidadVehiculo { get; set; }

    [Column("ChoferAsignado")]
    public int ChoferAsignadoId { get; set; }

    [ForeignKey(nameof(ChoferAsignadoId))]
    public ChoferesAutorizados ChoferAsignado { get; set; } = null!;

    public bool EstadoVehiculo { get; set; }
}