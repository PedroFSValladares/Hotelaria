using Hotelaria.Models;
using Hotelaria.Exceptions;

namespace Hotelaria {
    static class Program {
        public static void Main() {
            string resposta = "sim";
            decimal valorReserva;
            int quantidadeDias;
            Reserva reserva;
            do {
                reserva = new Reserva();
                Console.Clear();
                Console.WriteLine("Menu de nova reserva.\n");
                Console.Write("Quantidade de dias reservados: ");
                
                while(!int.TryParse(Console.ReadLine(), out quantidadeDias)){
                    Console.WriteLine("O valor digitado deve ser um numero, tente novamente ou pressione \"Ctrl\" + \"c\" para cancelar a reserva.");
                    Console.Write("Quantidade de dias reservados: ");
                }
                reserva = new Reserva(quantidadeDias);
                reserva.CadastrarSuite(CriarSuite());
                try{
                    reserva.CadastrarHospedes(CriarHospedes());
                    valorReserva = reserva.CalcularValorDiaria();
                    Console.WriteLine($"O valor da reserva ficou {valorReserva:C}.");
                }catch(SuiteLotadaException){
                    Console.WriteLine("A quantidade de hospedes excede a capacidade da Suite, cancelando reserva.");
                }

                Console.Write("Deseja realizar mais uma reserva? ");
                resposta = Console.ReadLine().ToLower();
            }while(resposta == "sim");
        }

        static Suite CriarSuite() {
            string tipo;
            int capacidade;
            decimal valor;

            Console.WriteLine("Infomações da Suite:");
            Console.Write("Tipo: ");
            tipo = Console.ReadLine();

            Console.Write("Capacidade: ");
            while(!int.TryParse(Console.ReadLine(), out capacidade)) {
                Console.WriteLine("O valor digitado deve ser um numero, tente novamente ou pressione \"Ctrl\" + \"c\" para cancelar a reserva.");
                Console.Write("Capacidade: ");
            }

            Console.Write("Valor da diaria: R$");
            while (!decimal.TryParse(Console.ReadLine(), out valor)) {
                Console.WriteLine("O valor digitado deve ser um numero, tente novamente ou pressione \"Ctrl\" + \"c\" para cancelar a reserva.");
                Console.Write("Valor da diaria: ");
            }

            return new Suite(tipo, capacidade, valor);
        }

        static List<Pessoa> CriarHospedes() {
            List<Pessoa> hospedes = new List<Pessoa>();
            string nome, sobrenome;
            Console.WriteLine("\nInformações dos hospedes:");
            do {
                Console.Write("Nome: ");
                nome = Console.ReadLine();

                Console.Write("Sobrenome: ");
                sobrenome = Console.ReadLine();

                hospedes.Add(new Pessoa(nome, sobrenome));
                Console.Write("\nCadastrar mais um hospede? ");

            } while (Console.ReadLine().ToLower() == "sim");

            return hospedes;
        }
    }
}