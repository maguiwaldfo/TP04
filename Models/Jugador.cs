namespace TP04.Models;

Public class Jugador{

    public int IdJugador { get; set; }
    public string Nombre { get; set; }
    public string Posicion { get; set; }
    public int NumeroCamiseta { get; set; }
    public int IdSeleccion { get; set; }
    public string Imagen { get; set; }
    public Seleccion Seleccion { get; set; }
}
