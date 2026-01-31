using System;

using System.Diagnostics;
using System.Text;

//Criar banco e tabela se não existir

Database.CriarBancoETabela();

// ===== FUNÇÕES =====

//===== Validadores ====

static int ValidarID(string mensagem)
{
    int id;

    while (true)
    {
        Console.Write(mensagem);

        if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Digite um número válido.");
            continue;
        }

        var paises = PaisRepository.Listar();

        if (paises.Any(p => p.Id == id))
            return id;

        Console.WriteLine("ID não encontrado. Tente novamente.");
    }
}

static int ValidarInt(string mensagem)
{
    int valor;

    while (true)
    {
        Console.Write(mensagem);
        if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
            return valor;

        Console.WriteLine("Valor inválido. Tente novamente.");
    }
}

static string ValidarString(string mensagem)
{
    string valor;

    while (true)
    {
        Console.Write(mensagem);
        valor = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(valor))
            return valor.Trim().ToUpper();

        Console.WriteLine("Valor inválido. Tente novamente.");
    }
}

//===== Operações =====
//

static void Cadastrar()
{
    string nome = ValidarString("Nome do país: ");

    int populacao = ValidarInt("População: ");

    int areaTotal = ValidarInt("Área total: ");
    
    PaisRepository.Inserir(new Pais
    {
        Nome = nome,
        Populacao = populacao,
        AreaTotal = areaTotal
    });

    Console.WriteLine("País cadastrado com sucesso!");
}
//
static void Consultar()
{
    Console.WriteLine("\n============= CONSULTAR PAÍSES =============");

    var paises = PaisRepository.Listar();

    if (paises.Count == 0)
    {
        Console.WriteLine("Nenhum país cadastrado.");
        return;
    }

    foreach (var p in paises)
    {
        Console.WriteLine($"{p.Id} | {p.Nome} | População: {p.Populacao} | Área: {p.AreaTotal}");
    }
    //opção exportar CSV
    Console.WriteLine("\nDeseja baixar arquivo?");
    Console.WriteLine("1 - Não");
    Console.WriteLine("2 - Exportar CSV (Excel)");

    int opcao = ValidarInt("Opção: ");
    switch (opcao)
    {
        case 1:
            Console.WriteLine("Ok, retornando ao menu...");
            break;
        case 2:
            ExportarCsv(paises);
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

}
//
static void Editar()
{
    Console.WriteLine("\n============= EDITAR PAÍS =============");

    if (PaisRepository.Listar().Count == 0)
    {
        Console.WriteLine("Nenhum país cadastrado para editar.");
        return;
    }

    int id = ValidarID("ID do país a ser editado: ");
    
    string nome = ValidarString("Novo nome: ");
  
    int populacao = ValidarInt("Nova população: ");

    int area = ValidarInt("Nova área total: ");

    var pais = new Pais
    {
        Id = id,
        Nome = nome,
        Populacao = populacao,
        AreaTotal = area
    };

    PaisRepository.Atualizar(pais);

    Console.WriteLine("País atualizado com sucesso!");
}
//
static void Deletar()
{
    Console.WriteLine("\n============= DELETAR PAÍS =============");

    if (PaisRepository.Listar().Count == 0)
    {
        Console.WriteLine("Nenhum país cadastrado para deletar.");
        return;
    }

    int id = ValidarID("Digite o ID do país: ");

    PaisRepository.Deletar(id);
    Console.WriteLine("País deletado!");
}
//exportador CSV

static void ExportarCsv(List<Pais> paises)
{
    string caminho = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        "paises.csv"
    );

    var sb = new StringBuilder();

    // Cabeçalho
    sb.AppendLine("ID;NOME;POPULACAO;AREA_TOTAL");

    foreach (var p in paises)
    {
        sb.AppendLine($"{p.Id};{p.Nome};{p.Populacao};{p.AreaTotal}");
    }

    File.WriteAllText(caminho, sb.ToString(), Encoding.UTF8);

    Console.WriteLine($"Arquivo CSV gerado em: {caminho}");

    Process.Start(new ProcessStartInfo
    {
        FileName = caminho,
        UseShellExecute = true
    });
}
// ===== MENU =====

while (true)
{
    Console.WriteLine("============= MENU PRINCIPAL ============= ");
    Console.WriteLine("Opções:");
    Console.WriteLine(" ");
    Console.WriteLine("---------> 1. CADASTRAR PAÍSES");
    Console.WriteLine("---------> 2. CONSULTAR PAÍSES");
    Console.WriteLine("---------> 3. EDITAR PAÍSES");
    Console.WriteLine("---------> 4. DELETAR PAÍSES");
    Console.WriteLine(" ");
    Console.WriteLine("================ Sair : 0 ================ ");

    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine()!;

    switch (opcao)
    {
        case "1":
            Cadastrar();
            break;
        case "2":
            Consultar();
            break;
        case "3":
            Editar();
            break;
        case "4":
            Deletar();
            break;
        case "0":
            Console.WriteLine("Saindo...");
            return;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    Console.WriteLine("\nPressione ENTER para continuar...");
    Console.ReadLine();
    Console.Clear();
}



