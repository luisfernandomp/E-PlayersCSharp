using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe _equipe);
         List<Equipe> ReadAll();
         void Update(Equipe _equipe);
         void Delete(int _IdEquipe);

    }
}