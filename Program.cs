using System;

namespace MediaStorage
{

    class Program
    {
        static SerieRepository Series = new SerieRepository();
        static MovieRepository Movies = new MovieRepository();

        static void Main(string[] args)
        {
            string option = "";

            while (option.ToUpper() != "X")
            {
                option = GetOption();
                switch (option)
                {
                    case "1":
                        var menu = new SerieMenu(Series);
                        menu.Run();
                        continue;
                    case "2":
                        var menu2 = new MovieMenu(Movies);
                        menu2.Run();
                        continue;
                    case "3":
                        option = "X";
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

            Console.WriteLine("Até a próxima!");
        }

        private static string GetOption()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - Séries");
            Console.WriteLine("2 - Filmes");
            Console.WriteLine("3 - Sair");
            return Console.ReadLine();
        }

    }
}