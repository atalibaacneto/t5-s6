// COMEX
using ComexT2.Modelos;
using System.Text.Json;
string mensagemDeBoasVindas = "\nSeja Bem-vindo(a)!";
List<string> listaDeProdutos = new List<string>();
void ExibirLogo()
{
    Console.WriteLine(@"
░█████╗░░█████╗░███╗░░░███╗███████╗██╗░░██╗
██╔══██╗██╔══██╗████╗░████║██╔════╝╚██╗██╔╝
██║░░╚═╝██║░░██║██╔████╔██║█████╗░░░╚███╔╝░
██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░░██╔██╗░
╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗██╔╝╚██╗
░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚═╝
");
    Console.WriteLine(mensagemDeBoasVindas);
}


//Produto produto = new Produto();
//produto.Nome = "DVD";
//produto.Descricao = "DVD de Música";
//produto.Preco_unitario = 39.90;
//produto.Qtde = 23;

//Console.WriteLine($"Produto: {produto.Nome}");
//Console.WriteLine($"Descrição: {produto.Descricao}");
//Console.WriteLine($"Preço Unitário: R$ {produto.Preco_unitario}");
//Console.WriteLine($"Quantidade: {produto.Qtde}");

async Task MenuDeOpcoes()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para cadastrar produtos");
    Console.WriteLine("Digite 2 para listar produtos cadastrados");
    Console.WriteLine("Digite 3 Consultar API Externa");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            CadastrarProduto();
            break;
        case 2:
            ListarProdutos();
            break;
        case 3:
            await ConsultarApiExterna();
            break;
        case -1: Console.WriteLine("Tchau!");
            break;
        default: Console.WriteLine("Opção Inválida");
            break;
    }
}

async Task ConsultarApiExterna()
{
    using (HttpClient client = new HttpClient())
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Mostrndo produtos da API Externa");
            Console.WriteLine("********************************\n");
            string resposta = await client.GetStringAsync("https://fakestoreapi.com/products");
            var produtos = JsonSerializer.Deserialize<List<Produto>>(resposta);
            foreach (var produto in produtos)
            {
                Console.WriteLine($"\nNome: {produto.Nome}, " +
                    $"\nDescrição: {produto.Descricao}, " +
                    $"\nPreço: {produto.Preco_unitario}");
            }
            //Console.WriteLine(resposta);
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            MenuDeOpcoes();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro de leitura de API : {ex.Message}");
        }
    }
}

await MenuDeOpcoes();

void CadastrarProduto()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nCadastro de Produtos");
    Console.WriteLine("********************");
    Console.Write("\nDigite o Produto para cadastrar: ");
    string produtoCadastrado = Console.ReadLine()!;
    listaDeProdutos.Add(produtoCadastrado);
    Console.WriteLine($"\nO produto cadastrado foi: {produtoCadastrado}");
    Thread.Sleep(2000);
    MenuDeOpcoes();
}
void ListarProdutos()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nListar Produtos Cadastrados");
    Console.WriteLine("***************************\n");
    //for (int i = 0; i < listaDeProdutos.Count; i++)
    //{
    //    Console.WriteLine($"Produto: {listaDeProdutos[i]}");
    //}
    foreach (string produto in listaDeProdutos)
    {
        Console.WriteLine($"Produto: {produto}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Thread.Sleep(2000);
    MenuDeOpcoes();
 }
//Livro biblia = new Livro("Biblia");
//biblia.Isbn = "123456789";
//var identificacaoBiblia = biblia.Identificar();
//Console.WriteLine(identificacaoBiblia);

