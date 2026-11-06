using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    // classe de base pour tous les monstres
    public abstract class Monstre : Personnage
    {
        protected Monstre(int x, int y) : base(x, y)
        {
        }
    }
}
