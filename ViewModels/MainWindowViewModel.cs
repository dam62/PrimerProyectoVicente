using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrimerProyectoVicente.Models;

namespace PrimerProyectoVicente.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private string mensaje = string.Empty;
    
    [ObservableProperty] private bool condiciones = false;
    
    [ObservableProperty] private bool opcionesAvanzadas = false;
    
    [ObservableProperty] private List<MesaReservada> mesas = new();

    [ObservableProperty] private MesaReservada mesa = new();
    
    public List<string> listaEventos { set; get; }
    
    public MainWindowViewModel()
    {
        ListarEventos();
    }

    [RelayCommand]
    public void CargarMesas()
    {
        mesa = new MesaReservada();
        
    }
    
    [RelayCommand]
    private void ListarEventos()
    {
        listaEventos = new()
        {
            "Cumpleaños", "Comunión", "Boda", "Fiesta"
        };
        Mesa.evento = listaEventos[0];
    }

    [RelayCommand]
    public void CrearReserva()
    {
        mesa = new MesaReservada();
    }
}