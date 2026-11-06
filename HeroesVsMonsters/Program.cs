using System;
using System.Text;

namespace HeroesVsMonsters
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Partie partie = new Partie();

            bool continuer = true;

            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("=== Heroes Vs Monsters - Forêt de Shorewood ===");
                Console.WriteLine("1. Combats successifs (exercice de base)");
                Console.WriteLine("2. Plateau de 15 sur 15 (exercice supplémentaire)");
                Console.WriteLine("3. Quitter");

                string choix = Console.ReadLine();

                if (choix == "1")
                {
                    partie.LancerCombatsSuccessifs();
                }
                else if (choix == "2")
                {
                    partie.LancerPlateau();
                }
                else if (choix == "3")
                {
                    continuer = false;
                }
            }
        }
    }
}
