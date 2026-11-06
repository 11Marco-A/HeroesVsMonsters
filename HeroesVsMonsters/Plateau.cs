using System;
using System.Collections.Generic;

namespace HeroesVsMonsters
{
    public class Plateau
    {
        public const int Taille = 15;
        public const int Centre = Taille / 2;

        private const int NB_MONSTRES = 10;
        private const int DIST_MONSTRES = 3;
        private const int DIST_HEROS = 2;

        private Heros _heros;
        private List<Monstre> _monstres;

        public Plateau(Heros heros)
        {
            _heros = heros;
            _monstres = new List<Monstre>();

            // placer les monstres au début
            PlacerLesMonstres();
        }

        public int MonstresRestants
        {
            get { return _monstres.Count; }
        }

        public bool DeplacerHeros(int dx, int dy)
        {
            int newX = _heros.X + dx;
            int newY = _heros.Y + dy;

            // vérifier qu'on reste sur le plateau
            if (newX < 0 || newX >= Taille || newY < 0 || newY >= Taille)
            {
                return false;
            }

            _heros.Deplacer(dx, dy);
            return true;
        }

        public Monstre TrouverMonstreAdjacent()
        {
            Monstre resultat = null;

            foreach (Monstre m in _monstres)
            {
                int ecartX = m.X - _heros.X;
                if (ecartX < 0) ecartX = -ecartX;

                int ecartY = m.Y - _heros.Y;
                if (ecartY < 0) ecartY = -ecartY;

                if (ecartX + ecartY == 1)
                {
                    resultat = m;
                    break;
                }
            }

            return resultat;
        }

        public void RetirerMonstre(Monstre monstre)
        {
            _monstres.Remove(monstre);
        }

        public void Afficher(Monstre monstreVisible)
        {
            for (int y = 0; y < Taille; y++)
            {
                for (int x = 0; x < Taille; x++)
                {
                    // afficher le héros
                    if (x == _heros.X && y == _heros.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(_heros.Symbole + " ");
                        Console.ResetColor();
                    }
                    // afficher le monstre visible s'il y en a un
                    else if (monstreVisible != null && x == monstreVisible.X && y == monstreVisible.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(monstreVisible.Symbole + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        // case vide
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(". ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

        private void PlacerLesMonstres()
        {
            De coordonnee = new De(0, Taille - 1);
            int essais = 0;

            while (_monstres.Count < NB_MONSTRES)
            {
                essais++;

                // si on a essayé trop de fois, on recommence à zéro
                if (essais > 10000)
                {
                    _monstres.Clear();
                    essais = 0;
                }

                int x = coordonnee.Lance();
                int y = coordonnee.Lance();

                if (EmplacementValide(x, y))
                {
                    _monstres.Add(FabriqueDeMonstres.CreerAuHasard(x, y));
                }
            }
        }

        private bool EmplacementValide(int x, int y)
        {
            // pas trop proche du héros
            int distHeros = CalculerDistance(x, y, _heros.X, _heros.Y);
            if (distHeros < DIST_HEROS)
            {
                return false;
            }

            // pas trop proche des autres monstres
            foreach (Monstre m in _monstres)
            {
                int dist = CalculerDistance(x, y, m.X, m.Y);
                if (dist < DIST_MONSTRES)
                {
                    return false;
                }
            }

            return true;
        }

        private static int CalculerDistance(int x1, int y1, int x2, int y2)
        {
            int dx = x1 - x2;
            if (dx < 0) dx = -dx;

            int dy = y1 - y2;
            if (dy < 0) dy = -dy;

            // distance de Chebyshev (diagonale = 1)
            if (dx > dy)
                return dx;
            else
                return dy;
        }
    }
}
