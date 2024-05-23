using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte
Reserva reserva = new Reserva(diasReservados: 0);
reserva.CadastrarSuite(suite);

//Cadastra a quantidade de hóspedes e o nome deles
Console.Write("Digite a quantidade de hóspedes: ");
int quantidadeHospedes = int.Parse(Console.ReadLine());

for (int i = 0; i < quantidadeHospedes; i++)
{
    Console.Write($"Digite o nome do hóspede {i + 1}: ");
    string nome = Console.ReadLine();
    // Adicionar o hóspede à lista
    var hospede = new Pessoa(nome);
    hospedes.Add(hospede);
}

// Cadastrando os hóspedes na reserva.
try
{
    reserva.CadastrarHospedes(hospedes);
    Console.WriteLine("Hóspedes cadastrados com sucesso!");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Erro ao cadastrar hóspedes: {ex.Message}");
    return;
}

// Exibe a quantidade de hóspedes e o valor da diária
decimal valorTotal = reserva.CalcularValorDiaria();
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor total da reserva: {valorTotal:C}");