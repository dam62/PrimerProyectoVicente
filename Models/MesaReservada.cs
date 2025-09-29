using System;

namespace PrimerProyectoVicente.Models;

public class MesaReservada
{
    public string evento { get; set; } = string.Empty;
    public string cliente { get; set; } = string.Empty;
    public int asientos { get; set; } = 0;
    public DateTime fecha { get; set; } = DateTime.Today;
}