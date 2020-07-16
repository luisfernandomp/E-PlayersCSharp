using System;
using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Noticias : EplayersBase, INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }  
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/noticias.csv";

        public Noticias(){
            CreateFolderAndFile(PATH);
        }
        public void Create(Noticias _nt)
        {
            string[] Linhas = { PrepararLinha(_nt)};
            File.AppendAllLines(PATH, Linhas);
        }
        private string PrepararLinha(Noticias _nt){
            return $"{_nt.IdNoticia};{_nt.Titulo};{_nt.Texto};{_nt.Imagem}";
        }

        public List<Noticias> ReadAll()
        {
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias nt = new Noticias();
                nt.IdNoticia = Int32.Parse(linha[0]);
                nt.Titulo = linha[1];
                nt.Texto = linha[2];
                nt.Imagem = linha[3];

                noticias.Add(nt);
            }
            return noticias;
        }

        public void Update(Noticias _nt)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == _nt.IdNoticia.ToString());
            linhas.Add(PrepararLinha(_nt));
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int _ntId)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == _ntId.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}