namespace Hotelaria.Models {
    public class Pessoa {
        private string Nome { get; set; }
        private string Sobrenome { get; set; }

        public Pessoa(string Nome, string Sobrenome) {
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
        }

        public override string ToString() {
            return $"{Nome} {Sobrenome}";
        }
    }
}