using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces
{
    public interface INoticias
    {
         void Create(Noticias _nt);
         List<Noticias> ReadAll();
         void Update(Noticias _nt);
         void Delete(int _nt);

    }
}