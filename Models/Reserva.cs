using System.Security.Cryptography;
using System.Security.Principal;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            //Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                //Retorna uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new InvalidOperationException("A quantidade de hóspedes não pode exceder a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            //Cadastra a suíte
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            //Retorna a quantidade de hóspedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            //Retorna o valor da diária
            Console.Write("Digite a quantidade de dias reservados: ");
            int DiasReservados = int.Parse(Console.ReadLine());
            decimal valor = DiasReservados * Suite.ValorDiaria;

            //Caso os dias reservados forem maior ou igual a 10, concede um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;
        }
    }
}