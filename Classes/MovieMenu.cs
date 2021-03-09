using System;

namespace MediaStorage
{

    public class MovieMenu
    {
        private MovieRepository Movies;

        public MovieMenu(MovieRepository movies)
        {
            this.Movies = movies;
        }

        public void ShowList()
        {
            var movies = this.Movies.GetList();

            if (movies.Count == 0)
            {
                Console.WriteLine("Não existem filmes cadastrados!");
                return;
            }

            Console.WriteLine("Foram encontrados " + movies.Count + " filmes");
            foreach (var movie in movies)
            {
                var available = movie.GetAvailable();
                Console.WriteLine("#id: " + movie.GetId(), movie.GetTitle(), !available ? "* Não disponível *" : "");
            }

        }

        public string GetOption()
        {
            Console.WriteLine("1 - Visualizar todos os filmes");
            Console.WriteLine("2 - Visualizar um filme");
            Console.WriteLine("3 - Inserir um filme ao catálogo");
            Console.WriteLine("4 - Atualizar um filme do catálogo");
            Console.WriteLine("5 - Remover um filme do catálogo");
            Console.WriteLine("6 - Voltar");
            return Console.ReadLine();
        }

        private void ShowAll()
        {
            var movies = Movies.GetList();
            if (movies.Count == 0)
            {
                Console.WriteLine("Não há nenhum filme no catálogo");
                return;
            }

            foreach (var movie in movies)
            {
                var available = movie.GetAvailable();
                Console.WriteLine("#ID {0}: - {1} {2}", movie.GetId(), movie.GetTitle(), (!available ? "*Não disponível*" : ""));
            }
        }

        private void Show()
        {
            Console.Write("Informe o id: ");
            int id = int.Parse(Console.ReadLine());
            var movie = Movies.FindMediaById(id);
            Console.WriteLine(movie);

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
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            int genre = int.Parse(Console.ReadLine());
            Movies.Insert(new Movie(Movies.NextId(), (Genre)genre, title, description, year));
            Console.WriteLine("Filme adicionado: " + title);
        }

        private void Update()
        {
            Console.WriteLine("Informe o id do filme: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Informe o título: ");
            string title = Console.ReadLine();
            Console.Write("Informe a descrição: ");
            string description = Console.ReadLine();
            Console.Write("Informe o ano de lançamento: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Selecione o gênero: ");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            int genre = int.Parse(Console.ReadLine());
            Movies.Update(id, new Movie(id, (Genre)genre, title, description, year));
            Console.WriteLine("Filme atualizado: " + title);
        }

        private void Delete()
        {
            Console.WriteLine("Informe o id: ");
            int id = int.Parse(Console.ReadLine());
            Movies.Delete(id);
            Console.WriteLine("Filme removido!");
        }

        public void Run()
        {
            string option = "";

            while (option.ToUpper() != "X")
            {
                Console.WriteLine("Catálogo de filmes");
                option = GetOption();
                switch (option)
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