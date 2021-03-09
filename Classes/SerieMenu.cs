using System;

namespace MediaStorage
{

    public class SerieMenu
    {
        private SerieRepository Series;

public SerieMenu(SerieRepository series)
{
    this.Series = series;
}

public void ShowList()
{
var series = this.Series.GetList();

if(series.Count == 0)
{
    Console.WriteLine("Não existem filmes cadastrados!");
return;
}

Console.WriteLine("Foram encontrados " + series.Count + " filmes");
foreach(var serie in series)
{
    var available = serie.GetAvailable();
Console.WriteLine("#id: " + serie.GetId(), serie.GetTitle(), !available ? "* Não disponível *" : "");
}

}

public string GetOption()
{
    Console.WriteLine("1 - Visualizar ttodas as séries");
    Console.WriteLine("2 - Visualizar uma série");
    Console.WriteLine("3 - Inserir uma série ao catálogo");
    Console.WriteLine("4 - Atualizar uma série do catálogo");
    Console.WriteLine("5 - Remover uma série do catálogo");
    Console.WriteLine("6 - Voltar");
    return Console.ReadLine();
}

private void ShowAll()
{
var series = Series.GetList();
if(series.Count == 0)
{
    Console.WriteLine("Não há nenhuma série no catálogo");
    return;
}

foreach(var serie in series)
{
    var available = serie.GetAvailable();
    Console.WriteLine("#ID {0}: - {1} {2}", serie.GetId(), serie.GetTitle(), (!available ? "*Não disponível*" : ""));
}
}

private void Show()
{
Console.Write("Informe o id: ");
int id = int.Parse(Console.ReadLine());
var serie = Series.FindMediaById(id);
Console.WriteLine(serie);

}

public void Insert()
{
    Console.Write("Informe o título: ");
    string title = Console.ReadLine();
    Console.Write("Informe a descrição: ");
    string description = Console.ReadLine();
 Console.Write("Informe o ano de lançamento: ");
    int year = int.Parse(Console.ReadLine());
    Console.WriteLine("Selecione o gênero: ");
    foreach(int i in Enum.GetValues(typeof(Genre)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
    }

int genre = int.Parse(Console.ReadLine());
Series.Insert(new Serie(Series.NextId(), (Genre) genre, title, description, year));
Console.WriteLine("Série adicionada: " + title);
}

private void Update()
{
    Console.WriteLine("Informe o id da série: ");
    int id = int.Parse(Console.ReadLine());
Console.Write("Informe o título: ");
    string title = Console.ReadLine();
    Console.Write("Informe a descrição: ");
    string description = Console.ReadLine();
 Console.Write("Informe o ano de lançamento: ");
    int year = int.Parse(Console.ReadLine());
    Console.WriteLine("Selecione o gênero: ");
    foreach(int i in Enum.GetValues(typeof(Genre)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
    }

int genre = int.Parse(Console.ReadLine());
Series.Update(id, new Serie(id, (Genre) genre, title, description, year));
Console.WriteLine("Série atualizada: " + title);
}

private void Delete()
{
Console.WriteLine("Informe o id: ");
int id = int.Parse(Console.ReadLine());
Series.Delete(id);
Console.WriteLine("Série removida!");
}

public void Run()
{
    string option = "";

    while(option.ToUpper() != "X")
    {
        option = GetOption();
        switch(option)
        {
            case "1":
            ShowAll();
            continue;
            case "2":
            Show();
            continue;
            case "3":
            Insert();
            continue;
            case "4":
            Update();
            continue;
            case "5":
            Delete();
            continue;
            case "6":
            option = "X";
            break;
            default:
            Console.Write("Opção inválida!");
            continue;
        }
    }

    Console.WriteLine("Voltando...");
}

    }
}