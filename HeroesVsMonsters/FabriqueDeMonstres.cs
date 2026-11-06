using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    // fabrique pour créer des monstres aléatoires
    public static class FabriqueDeMonstres
    {
        public static Monstre CreerAuHasard(int x, int y)
        {
            // choisir un monstre au hasard entre 1 et 3
            De de = new De(1, 3);
            int resultat = de.Lance();

            if (resultat == 1)
            {
                return new Loup(x, y);
            }
            else if (resultat == 2)
            {
                return new Orque(x, y);
            }
            else
            {
                return new Dragonnet(x, y);
            }
        }
    }
}
