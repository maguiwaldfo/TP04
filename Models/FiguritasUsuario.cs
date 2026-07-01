namespace TP04.Models;

Public class FiguritasUsuario{

    public int Id { get; set; }
    public int IdJugador { get; set; }
    public int Cantidad { get; set; }
    public bool Pegada { get; set; }
    public Jugador Jugador { get; set; }
}