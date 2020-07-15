using System;
using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/equipe.csv";

        public Equipe(){
            CreateFolderAndFile(PATH);
        }
        public void Create(Equipe _equipe)
        {
            string[] Linhas = { PrepararLinha(_equipe)};
            File.AppendAllLines(PATH, Linhas);
        }
        private string PrepararLinha(Equipe _equipe){
            return $"{_equipe.IdEquipe};{_equipe.Nome};{_equipe.Imagem}";
        }
        public void Delete(int _IdEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == _IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
         
        public void Update(Equipe _equipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == _equipe.IdEquipe.ToString());
            linhas.Add(PrepararLinha(_equipe));
            RewriteCSV(PATH, linhas);
        }

         
    }
}