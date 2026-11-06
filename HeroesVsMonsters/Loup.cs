using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    public class Loup : Monstre, IDepecable
    {
        public Loup(int x, int y) : base(x, y)
        {
            // générer la quantité de cuir aléatoirement
            De de = new De(1, 4);
            Cuir = de.Lance();
        }

        public override string Nom
        {
            get { return "Loup"; }
        }

        public override char Symbole
        {
            get { return 'L'; }
        }

        public int Cuir { get; }
    }
}
