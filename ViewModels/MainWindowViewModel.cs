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
    
    public List<string> ListaEventos { set; get; }
    
    public MainWindowViewModel()
    {
        ListarEventos();
        MostrarReserva();
    }
    
    private void ListarEventos()
    {
        ListaEventos = new()
        {
            "Cumpleaños", "Comunión", "Boda", "Fiesta"
        };
        Mesa.Evento = ListaEventos[0];
    }
    
    [RelayCommand]
    public void ComprobarFecha()
    {
        CheckDate();
    }
    
    private bool CheckDate()
    {
        if (Mesa.Fecha < DateTime.Today)
        {
            Mensaje = "La fecha no puede ser inferior a hoy";
            return false;
        }
        else
        {
            Mensaje = string.Empty;
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
    public void BotonCancelar()
    {
        Mesa = new();
        ModoCrear = true;
        ModoEditar = false;
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
    public void MostrarReserva()
    {
        MesaReservada m = new MesaReservada();
        m.Evento = "Cumpleaños";
        m.Cliente = "manolo@gmail.com";
        m.Asientos = 5;
        m.Fecha = DateTime.Now;
        Reservas.Add(m);
        
        MesaReservada m2 = new MesaReservada();
        m2.Evento = "Comunión";
        m2.Cliente = "pepe@gmail.com";
        m2.Asientos = 12;
        m2.Fecha = DateTime.Now;
        Reservas.Add(m2);
        
        MesaReservada m3 = new MesaReservada();
        m3.Evento = "Fiesta";
        m3.Cliente = "alex@gmail.com";
        m3.Asientos = 8;
        m3.Fecha = DateTime.Now;
        Reservas.Add(m3);
    }

    [RelayCommand]
    public void CrearReserva(object parameter)
    {
        bool comprobarFecha = CheckDate();
        
        if (comprobarFecha == false)
        {
            return;
        }
        
        if (!CheckDate())
        {
            Mensaje = "Tienes que indicar la fecha";
            return;
        }
        
        CheckBox check = (CheckBox)parameter;
        
        if (check.IsChecked is false)
        {
            Mensaje = "Debes marcar el check";
            check.Foreground = Brushes.Crimson;
            check.FontWeight = FontWeight.Bold;
            return;
        }

        if (string.IsNullOrWhiteSpace(Mesa.Cliente))
        {
            Mensaje = "Tienes que poner el email";
        }
        else
        {
            Reservas.Add(Mesa);
            Mensaje = string.Empty;
            Mesa = new MesaReservada();
            check.IsChecked = false;
        }
    }
}