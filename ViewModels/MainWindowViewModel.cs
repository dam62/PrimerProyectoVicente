using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrimerProyectoVicente.Models;

namespace PrimerProyectoVicente.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string mensaje = string.Empty;
    
    [ObservableProperty] private bool condiciones = false;
    
    [ObservableProperty] private bool opcionesAvanzadas = false;

    [ObservableProperty] private MesaReservada mesa = new();
    
    [ObservableProperty] private bool modoEditar = false;
    
    [ObservableProperty] private bool modoCrear = true;
    
    [ObservableProperty] private MesaReservada mesaEditar = new ();
    
    [ObservableProperty] private ObservableCollection<MesaReservada> reservas = new();
    
    public List<string> listaEventos { set; get; }
    
    public MainWindowViewModel()
    {
        ListarEventos();
    }
    
    private void ListarEventos()
    {
        listaEventos = new()
        {
            "Cumpleaños", "Comunión", "Boda", "Fiesta"
        };
        Mesa.evento = listaEventos[0];
    }
    
    [RelayCommand]
    public void ComprobarFecha()
    {
        CheckDate();
    }
    
    private bool CheckDate()
    {
        if (Mesa.fecha < DateTime.Today)
        {
            Mensaje = "La fecha no puede ser inferior a hoy";
            return false;
        }
        else
        {
            Mensaje = string.Empty; //Mensaje = "";
            return true;
        }
    }
    
    [RelayCommand]
    public void EditarMesa()
    {
        Mesa = MesaEditar;
        ModoCrear = false;
        ModoEditar = true;
    }

    [RelayCommand]
    public void MostrarOpcionesAvanzadas()
    {
        if (OpcionesAvanzadas)
        {
            OpcionesAvanzadas = false;
        }
        else
        {
            OpcionesAvanzadas = true;
        }
        
    }

    [RelayCommand]
    public void EstadoInicialCheck(object parameter)
    {
        CheckBox check =  (CheckBox)parameter;

        if (check.IsChecked == true)
        {
            check.Foreground = Brushes.Black;
            check.FontWeight = FontWeight.Bold;
        }
    }

    [RelayCommand]
    public void CrearReserva()
    {
        mesa = new MesaReservada();
    }
}