using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    // classe pour lancer un dé
    public class De
    {
        private static Random _aleatoire = new Random();

        public int Minimum { get; }
        public int Maximum { get; }

        public De(int minimum, int maximum)
        {
            // vérifier que minimum est pas plus grand que maximum
            if (minimum > maximum)
            {
                throw new ArgumentException("Le minimum ne peut pas dépasser le maximum.");
            }

            Minimum = minimum;
            Maximum = maximum;
        }

        // lance le dé et retourne un résultat aléatoire
        public int Lance()
        {
            int resultat = _aleatoire.Next(Minimum, Maximum + 1);
            return resultat;
        }
    }
}
