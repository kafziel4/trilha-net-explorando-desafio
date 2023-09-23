using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagemTests.Helpers
{
    public static class ReservaHelper
    {
        public static Reserva CriarReserva(int diasReservados) =>
            new(diasReservados: diasReservados);
    }
}
