using System;

namespace MediaStorage
{

    public class Serie : MediaId
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Available { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Available = true;
        }

        public override string ToString()
        {
            string text = "";

            text += "Gênero: " + this.Genre + Environment.NewLine;
            text += "Título: " + this.Title + Environment.NewLine;
            text += "Descrição: " + this.Description + Environment.NewLine;
            text += "Ano: " + this.Year + Environment.NewLine;
            return text;
        }

        public int GetId()
        {
            return this.Id;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public void Delete()
        {
            this.Available = false;
        }

        public bool GetAvailable()
        {
            return this.Available;
        }
    }
}