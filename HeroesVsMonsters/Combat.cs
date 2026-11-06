using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    public static class Combat
    {
        public static void Lancer(Heros heros, Monstre monstre)
        {
            Console.WriteLine("Un " + monstre.Nom + " surgit de la forêt !");
            Console.WriteLine(heros);
            Console.WriteLine(monstre);
            Console.WriteLine();

            // boucle de combat tant que les deux sont en vie
            while (heros.EstVivant && monstre.EstVivant)
            {
                // le héros frappe d'abord
                int degatsHeros = heros.Frappe(monstre);
                int pvMonstre = monstre.PV;
                if (pvMonstre < 0)
                    pvMonstre = 0;
                Console.WriteLine(heros.Nom + " frappe " + monstre.Nom + " : " + degatsHeros
                    + " dégât(s), il lui reste " + pvMonstre + " PV.");

                // le monstre frappe seulement s'il est encore vivant
                if (monstre.EstVivant)
                {
                    int degatsMonstre = monstre.Frappe(heros);
                    int pvHeros = heros.PV;
                    if (pvHeros < 0)
                        pvHeros = 0;
                    Console.WriteLine(monstre.Nom + " frappe " + heros.Nom + " : " + degatsMonstre
                        + " dégât(s), il lui reste " + pvHeros + " PV.");
                }
            }

            Console.WriteLine();

            if (heros.EstVivant)
            {
                heros.Depouiller(monstre);
                heros.SeReposer();
                Console.WriteLine("Le " + monstre.Nom + " est mort. Le héros le dépouille et se repose.");
                Console.WriteLine(heros);
            }
            else
            {
                Console.WriteLine("Le héros a été tué par le " + monstre.Nom + ".");
            }
        }
    }
}
