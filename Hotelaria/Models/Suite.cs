namespace Hotelaria.Models {
    public class Suite {
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria) {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public override string ToString() {
            return $"Tipo: {TipoSuite}\n" +
                $"Capacidade: {Capacidade} hospede(s)\n" +
                $"Valor da diaria: {ValorDiaria:C}\n";
        }
    }
}
