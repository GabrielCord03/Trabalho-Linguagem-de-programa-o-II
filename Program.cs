using System;
using System.Collections.Generic;
using System.Linq;
public class SistemaDeEventos
{
    static List<Evento> eventos = new List<Evento>();
    static List<Contato> contatos = new List<Contato>();

    static void Main(string[] args)
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("=== Menu ===");
            Console.WriteLine("1. Cadastrar Evento");
            Console.WriteLine("2. Listar Eventos em um Período");
            Console.WriteLine("3. Pesquisar Evento por Data");
            Console.WriteLine("4. Editar Evento");
            Console.WriteLine("5. Pesquisar Contato");
            Console.WriteLine("6. Excluir Evento");
            Console.WriteLine("7. Exportar Dados de um Evento para .txt");
            Console.WriteLine("8. Sair");
            Console.WriteLine("============");

            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    CadastrarEvento();
                    break;
                case "2":
                    ListarEventos();
                    break;
                case "3":
                    PesquisarEventoPorData();
                    break;
                case "4":
                    EditarEvento();
                    break;
                case "5":
                    PesquisarContato();
                    break;
                case "6":
                    ExcluirEvento();
                    break;
                case "7":
                    ExportarEventoParaTxt();
                    break;
                case "8":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                    break;
            }
        }
    }

    static void CadastrarEvento()
    {
        Console.WriteLine("=== Cadastro de Evento ===");
       
        Console.Write("Título do Evento: ");
        string titulo = Console.ReadLine();
        Console.Write("Data (DD/MM/AAAA): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Hora Inicial (HH:MM): ");
        DateTime horaInicial = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);
        Console.Write("Hora Final (HH:MM): ");
        DateTime horaFinal = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);
        Console.Write("Descrição do Evento: ");
        string descricao = Console.ReadLine();
        Console.Write("Quantidade de Pessoas: ");
        int quantidadePessoas = int.Parse(Console.ReadLine());
        Console.Write("Público Alvo: ");
        string publicoAlvo = Console.ReadLine();

        Console.WriteLine("=== Contato Responsável ===");
        Console.Write("Nome: ");
        string nomeContato = Console.ReadLine();
        Console.Write("Telefone: ");
        string telefoneContato = Console.ReadLine();
        Console.Write("E-mail: ");
        string emailContato = Console.ReadLine();

        
        Evento eventoNovo = new Evento(titulo, data, horaInicial, horaFinal, descricao, quantidadePessoas, publicoAlvo,
                                       new Contato(nomeContato, telefoneContato, emailContato));
        Contato contatoNovo = new Contato(nomeContato, telefoneContato, emailContato);

        eventos.Add(eventoNovo);
        contatos.Add(contatoNovo);

        Console.WriteLine("Evento cadastrado com sucesso!");
    }

    static void ListarEventos()
    {
        Console.WriteLine("=== Listagem de Evento ===");
        Console.Write("Insira a data inicial (DD/MM/AAAA): ");
        DateTime dataIni = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Insira a data final (DD/MM/AAAA): ");
        DateTime dataFim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        foreach (Evento evento in eventos)
        {
            if (evento.Data >= dataIni && evento.Data <= dataFim)
            {
                Console.WriteLine($"ID: {evento.Id}");
                Console.WriteLine($"Título: {evento.Titulo}");
                Console.WriteLine($"Data: {evento.Data.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Hora Inicial: {evento.HoraIni.ToString("HH:mm")}");
                Console.WriteLine($"Hora Final: {evento.HoraFim.ToString("HH:mm")}");
                Console.WriteLine($"Descrição: {evento.Descricao}");
                Console.WriteLine($"Quantidade de Pessoas: {evento.QuantidadePessoas}");
                Console.WriteLine($"Público Alvo: {evento.PublicoAlvo}");
                Console.WriteLine($"Contato Responsável: {evento.Responsavel.Nome}, {evento.Responsavel.Telefone}, {evento.Responsavel.Email}");
                Console.WriteLine();
            }
        }
    }
    static void PesquisarEventoPorData()
    {
        Console.WriteLine("=== Pesquisa de Evento por data ===");
        Console.Write("Insira a data do evento: (DD/MM/AAAA): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        foreach (Evento evento in eventos)
        {
            Console.WriteLine("=== Nesta data foram encontrado os seguintes eventos: ===");
            if (evento.Data == data )
            {
                Console.WriteLine($"ID: {evento.Id}");
                Console.WriteLine($"Título: {evento.Titulo}");
                Console.WriteLine($"Data: {evento.Data.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Hora Inicial: {evento.HoraIni.ToString("HH:mm")}");
                Console.WriteLine($"Hora Final: {evento.HoraFim.ToString("HH:mm")}");
                Console.WriteLine($"Descrição: {evento.Descricao}");
                Console.WriteLine($"Quantidade de Pessoas: {evento.QuantidadePessoas}");
                Console.WriteLine($"Público Alvo: {evento.PublicoAlvo}");
                Console.WriteLine($"Contato Responsável: {evento.Responsavel.Nome}, {evento.Responsavel.Telefone}, {evento.Responsavel.Email}");
                Console.WriteLine();
            }
        }

    }

    static void EditarEvento()
    {
        Console.WriteLine("=== Editar Evento ===");

        Console.WriteLine("Eventos Disponíveis:");
        foreach (Evento evento in eventos)
        {
            Console.WriteLine($"ID: {evento.Id}, Título: {evento.Titulo}");
        }

        Console.Write("Insira o ID do evento que deseja editar: ");
        string idEvento = Console.ReadLine();

        Evento Editarevento = eventos.Find(e => e.Id == idEvento);

        if (Editarevento != null)
        {
            Console.WriteLine("Escolha a propriedade que deseja editar:");
            Console.WriteLine("1. Título do Evento");
            Console.WriteLine("2. Data");
            Console.WriteLine("3. Hora Inicial");
            Console.WriteLine("4. Hora Final");
            Console.WriteLine("5. Descrição do Evento");
            Console.WriteLine("6. Quantidade de Pessoas");
            Console.WriteLine("7. Público Alvo");

            Console.Write("Escolha uma opção: ");
            string escolhaPropriedade = Console.ReadLine();

            switch (escolhaPropriedade)
            {
                case "1":
                    Console.Write("Novo Título do Evento: ");
                    Editarevento.Titulo = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Nova Data (DD/MM/AAAA): ");
                    Editarevento.Data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    break;
                case "3":
                    Console.Write("Nova Hora Inicial (HH:MM): ");
                    Editarevento.HoraIni = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);
                    break;
                case "4":
                    Console.Write("Nova Hora Final (HH:MM): ");
                    Editarevento.HoraFim = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);
                    break;
                case "5":
                    Console.Write("Nova Descrição do Evento: ");
                    Editarevento.Descricao = Console.ReadLine();
                    break;
                case "6":
                    Console.Write("Nova Quantidade de Pessoas: ");
                    Editarevento.QuantidadePessoas = int.Parse(Console.ReadLine());
                    break;
                case "7":
                    Console.Write("Novo Público Alvo: ");
                    Editarevento.PublicoAlvo = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }

            Console.WriteLine("Evento editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Evento não encontrado. Certifique-se de inserir o ID correto.");
        }
    }

    static void PesquisarContato()
    {
        Console.WriteLine("=== Pesquisa de Contato ===");
        Console.Write("Insira o nome do contato: ");
        string Nome = Console.ReadLine();

        foreach (Contato contato in contatos)
        {
            if (contato.Nome == Nome)
            {
                Console.WriteLine($"Nome: {contato.Nome}");
                Console.WriteLine($"Telefone: {contato.Telefone}");
                Console.WriteLine($"Email: {contato.Email}");
                Console.WriteLine();
            }
        }
    }

    static void ExcluirEvento()
    {
        Console.WriteLine("=== Excluir Evento ===");

        Console.WriteLine("Eventos Disponíveis:");
        foreach (Evento evento in eventos)
        {
            Console.WriteLine($"ID: {evento.Id}, Título: {evento.Titulo}");
        }

        Console.Write("Insira o ID do evento que deseja excluir: ");
        string idEvento = Console.ReadLine();

        Evento Excluirevento = eventos.Find(e => e.Id == idEvento);

        if (Excluirevento != null)
        {
            eventos.Remove(Excluirevento);
            Console.WriteLine("Evento excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Evento não encontrado. Certifique-se de inserir o ID correto.");
        }
    }

    static void ExportarEventoParaTxt()
    {
        Console.WriteLine("=== Exportar Dados de um Evento para .txt ===");

        Console.WriteLine("Eventos Disponíveis:");
        foreach (Evento evento in eventos)
        {
            Console.WriteLine($"ID: {evento.Id}, Título: {evento.Titulo}");
        }

        Console.Write("Insira o ID do evento que deseja exportar: ");
        string idEvento = Console.ReadLine();

        Evento eventoExportar = eventos.Find(e => e.Id == idEvento);

        if (eventoExportar != null)
        {
            string dadosEvento = $"ID: {eventoExportar.Id}\n" +
                                 $"Título: {eventoExportar.Titulo}\n" +
                                 $"Data: {eventoExportar.Data.ToString("dd/MM/yyyy")}\n" +
                                 $"Hora Inicial: {eventoExportar.HoraIni.ToString("HH:mm")}\n" +
                                 $"Hora Final: {eventoExportar.HoraFim.ToString("HH:mm")}\n" +
                                 $"Descrição: {eventoExportar.Descricao}\n" +
                                 $"Quantidade de Pessoas: {eventoExportar.QuantidadePessoas}\n" +
                                 $"Público Alvo: {eventoExportar.PublicoAlvo}\n" +
                                 $"Contato Responsável: {eventoExportar.Responsavel.Nome}, {eventoExportar.Responsavel.Telefone}, {eventoExportar.Responsavel.Email}";

            string caminhoArquivo = $"evento_{eventoExportar.Id}.txt";

            try
            {
                File.WriteAllText(caminhoArquivo, dadosEvento);
                Console.WriteLine($"Os dados do evento foram exportados para o arquivo: {caminhoArquivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao exportar os dados do evento: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Evento não encontrado. Certifique-se de inserir o ID correto.");
        }
    }
}

