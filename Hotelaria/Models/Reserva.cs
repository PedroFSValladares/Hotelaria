using Hotelaria.Exceptions;

namespace Hotelaria.Models {
    public class Reserva {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva(List<Pessoa> hospedes, Suite suite, int diasReservados) {
            Hospedes = hospedes;
            Suite = suite;
            DiasReservados = diasReservados;
        }

        public Reserva(int diasReservados) {
            DiasReservados = diasReservados;
        }

        public Reserva() { }

        public void CadastrarHospedes(List<Pessoa> hospedes) {
            if (hospedes.Count <= Suite.Capacidade) {
                Hospedes = hospedes;
            } else {
                throw new SuiteLotadaException();
            }
        }

        public void CadastrarSuite(Suite suite) {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes() {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria() {
            decimal valor = Suite.ValorDiaria * DiasReservados;
            return (DiasReservados >= 10) ? valor - valor * 0.1M : valor;
        }
    }
}
