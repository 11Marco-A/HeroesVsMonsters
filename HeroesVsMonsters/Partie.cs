using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    public class Partie
    {
        public void LancerCombatsSuccessifs()
        {
            Heros heros = ChoisirHeros();
            int monstresTues = 0;

            while (heros.EstVivant)
            {
                Console.Clear();

                // créer un monstre aléatoire et lancer le combat
                Monstre monstre = FabriqueDeMonstres.CreerAuHasard(0, 0);
                Combat.Lancer(heros, monstre);

                if (heros.EstVivant)
                {
                    monstresTues++;
                    Console.WriteLine();
                    Console.WriteLine("Appuyez sur une touche pour continuer...");
                    Console.ReadKey(true);
                }
            }

            // afficher le bilan à la fin
            Console.WriteLine();
            Console.WriteLine("Monstres tués : " + monstresTues);
            Console.WriteLine("Butin : " + heros.Or + " or, " + heros.Cuir + " cuir");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true);
        }

        public void LancerPlateau()
        {
            Heros heros = ChoisirHeros();
            Plateau plateau = new Plateau(heros);
            int monstresTues = 0;
            bool abandon = false;

            while (heros.EstVivant && plateau.MonstresRestants > 0 && abandon == false)
            {
                Console.Clear();
                plateau.Afficher(null);
                Console.WriteLine();
                Console.WriteLine(heros);
                Console.WriteLine("Monstres restants : " + plateau.MonstresRestants);
                Console.WriteLine("Flèches ou ZQSD pour bouger, Échap pour quitter.");

                ConsoleKey touche = Console.ReadKey(true).Key;

                if (touche == ConsoleKey.Escape)
                {
                    abandon = true;
                }
                else
                {
                    // essayer de déplacer le héros
                    bool aBouge = false;

                    if (touche == ConsoleKey.UpArrow || touche == ConsoleKey.Z || touche == ConsoleKey.W)
                    {
                        aBouge = plateau.DeplacerHeros(0, -1);
                    }
                    else if (touche == ConsoleKey.DownArrow || touche == ConsoleKey.S)
                    {
                        aBouge = plateau.DeplacerHeros(0, 1);
                    }
                    else if (touche == ConsoleKey.LeftArrow || touche == ConsoleKey.Q || touche == ConsoleKey.A)
                    {
                        aBouge = plateau.DeplacerHeros(-1, 0);
                    }
                    else if (touche == ConsoleKey.RightArrow || touche == ConsoleKey.D)
                    {
                        aBouge = plateau.DeplacerHeros(1, 0);
                    }

                    // si on a bougé, vérifier s'il y a un monstre à côté
                    if (aBouge)
                    {
                        Monstre monstre = plateau.TrouverMonstreAdjacent();

                        if (monstre != null)
                        {
                            Console.Clear();
                            plateau.Afficher(monstre);
                            Console.WriteLine();
                            Combat.Lancer(heros, monstre);

                            if (heros.EstVivant)
                            {
                                plateau.RetirerMonstre(monstre);
                                monstresTues++;
                                Console.WriteLine();
                                Console.WriteLine("Appuyez sur une touche pour continuer...");
                                Console.ReadKey(true);
                            }
                        }
                    }
                }
            }

            Console.WriteLine();

            if (abandon)
            {
                Console.WriteLine("Le héros quitte la forêt de Shorewood.");
            }
            else if (heros.EstVivant)
            {
                Console.WriteLine("Victoire ! La forêt de Shorewood est libérée.");
            }

            // afficher le bilan
            Console.WriteLine();
            Console.WriteLine("Monstres tués : " + monstresTues);
            Console.WriteLine("Butin : " + heros.Or + " or, " + heros.Cuir + " cuir");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true);
        }

        private static Heros ChoisirHeros()
        {
            Console.Clear();
            Console.WriteLine("Choisissez votre héros :");
            Console.WriteLine("1. Humain (+1 Force, +1 Endurance)");
            Console.WriteLine("2. Nain (+2 Endurance)");

            while (true)
            {
                string choix = Console.ReadLine();

                if (choix == "1")
                {
                    return new Humain(Plateau.Centre, Plateau.Centre);
                }
                else if (choix == "2")
                {
                    return new Nain(Plateau.Centre, Plateau.Centre);
                }
                else
                {
                    Console.WriteLine("Tapez 1 ou 2.");
                }
            }
        }
    }
}
