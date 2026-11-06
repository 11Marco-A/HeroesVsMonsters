using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    // le dragonnet a de l'or ET du cuir
    public class Dragonnet : Monstre, IPossedeOr, IDepecable
    {
        public Dragonnet(int x, int y) : base(x, y)
        {
            De de1 = new De(1, 6);
            Or = de1.Lance();

            De de2 = new De(1, 4);
            Cuir = de2.Lance();
        }

        public override string Nom
        {
            get { return "Dragonnet"; }
        }

        public override char Symbole
        {
            get { return 'D'; }
        }

        // le dragonnet a +1 en endurance
        public override int Endurance
        {
            get { return base.Endurance + 1; }
        }

        public int Or { get; }
        public int Cuir { get; }
    }
}
