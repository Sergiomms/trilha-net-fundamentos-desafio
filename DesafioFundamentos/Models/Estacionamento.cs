namespace DesafioFundamentos.Models
{
  public class Estacionamento
  {
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
      this.precoInicial = precoInicial;
      this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo com 6 digitos para estacionar:");
      string placa = Console.ReadLine().ToUpper();
      bool placaExiste = veiculos.Contains(placa);

      if (placaExiste)
      {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Veículo já cadastrado!");
        Console.WriteLine("---------------------------------------------");
        AdicionarVeiculo();
      }
      else
      {
        if (placa.Length != 6)
        {
          Console.WriteLine("---------------------------------------------");
          Console.WriteLine("A placa deve conter 6 digitos!");
          Console.WriteLine("---------------------------------------------");
          AdicionarVeiculo();
        }
        else
        {
          veiculos.Add(placa);
          Console.WriteLine("---------------------------------------------");
          Console.WriteLine("Veículo adicionado com sucesso!");
          Console.WriteLine("---------------------------------------------");
        }
      }

    }

    public void RemoverVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");

      string placa = Console.ReadLine().ToUpper();

      // Verifica se o veículo existe
      if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
      {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
        Console.WriteLine("---------------------------------------------");

        int horas = 0;
        decimal valorTotal = 0;
        try
        {
          horas = Convert.ToInt32(Console.ReadLine());

          valorTotal = precoInicial + precoPorHora * horas;

          veiculos.Remove(placa.ToUpper());

          Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }
        catch (FormatException)
        {
          Console.WriteLine("---------------------------------------------");
          Console.WriteLine("As horas devem ser apenas números inteiros!");
          Console.WriteLine("---------------------------------------------");
          RemoverVeiculo();
        }

      }
      else
      {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        Console.WriteLine("---------------------------------------------");
      }
    }

    public void ListarVeiculos()
    {
      // Verifica se há veículos no estacionamento
      if (veiculos.Any())
      {
        Console.WriteLine("Os veículos estacionados são:");

        foreach(string veiculo in veiculos)
        {
          Console.WriteLine(veiculo);
        }
      }
      else
      {
        Console.WriteLine("Não há veículos estacionados.");
      }
    }
  }
}
