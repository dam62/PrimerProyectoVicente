using System;

namespace PrimerProyectoVicente.Models;

public class MesaReservada
{
    public string Evento { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public int Asientos { get; set; } = 0;
    public DateTime Fecha { get; set; } = DateTime.Today;
}