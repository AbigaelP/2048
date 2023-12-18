using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_test
{
    /*
     * Auteur: Abigaël Périsset
     * Date début: 23.11.2023
     * Date fin: 30.11.2023
     * Description: Déplacer des nombres positionner aléatoirement dans un tableau dans 4 directions distinctes et les fusionné : faire un 2028
     */
    internal class Program
    {
        // Définir l'aléatoire en dehors du void main pour gagner de la rapidité
        static Random random = new Random();

        // Déclarer le score
        static int score = 0;

        // Déclarer la victoire
        static bool gagner = false;

        // Déclarer le mouvement
        static bool controleMouvements = false;

        static void Main(string[] args)
        {
            // Initialisé le tableau 4 par 4
            int[,] tableau = new int[4, 4];

            // Créer une variable booléenne initialisée à true
            bool jeu = true;

            // Mettre deux nombre aléatoire
            for (int p = 0; p <= 1; p++)
            {
                Aleatoire(tableau);
            }
           
            AfficherTableau(tableau);

            //tableau2D[0, 0] = 1024; tableau2D[1,0] = 1024;

            //Une boucle while qui continue tant qu'il reste des 0 dans le tableau et que les variables booléennes restent sur true
            while (jeu && Controle(tableau))
            {
                //Détecter sur quelle touche l'utilisateur appuie
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                // Créer un switch pour les flèches directionnelles
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        //Fonction du mouvements des tuiles vers le haut
                        tableau = Haut(tableau);
                        break;
                    case ConsoleKey.DownArrow:
                        //Fonction du mouvements des tuiles vers le bas
                        tableau = Bas(tableau);
                        break;
                    case ConsoleKey.LeftArrow:
                        //Fonction du mouvements des tuiles vers la gauche
                        tableau = Gauche(tableau);
                        break;
                    case ConsoleKey.RightArrow:
                        //Fonction du mouvements des tuiles vers la droite
                        tableau = Droite(tableau);
                        break;
                    case ConsoleKey.C:
                        // Arrêter le programme si la touche C est pressée
                        jeu = false;
                        Environment.Exit(0);
                        break;
                    default:
                        //Message par défaut si une autre touche est pressée
                        Console.WriteLine("Appuyez sur une flèche directionnelle ou C pour arrêter.");
                        break;
                }

                //Générer un nombre aléatoire après le mouvement
                if (controleMouvements)
                {
                    Aleatoire(tableau);
                }
                // Afficher le tableau
                AfficherTableau(tableau);

                // Mettre le mouvements à false
                controleMouvements = false;

            }

            Console.ReadKey();
        }

        // Méthode qui controle si une case èà le nombre 2048
        static bool controleGagner(int[,] tableau)
        {
            int ligne = tableau.GetLength(0);  //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1);  //longueur de la dimmension y du tableau

            for (int i = 0; i < ligne; i++)
            {
                for (int j = 0; j < colone; j++)
                {
                    if (tableau[i, j] == 2048)
                    {
                        return true; // si 2028 est présent on return true
                    }
                }
            }

            return false; // aucun 2048 dans les tuiles
        }

        //Fonction déplacer les chiffres (tuiles) vers le bas
        static int[,] Bas(int[,] tableau)
        {
            int x, y, z, w;             //variable de position
            int[] bas = new int[4];

            //Passer dans chaques colones pour stocker les valeur des lignes et les manipuler
            for (int colone = 0; colone < tableau.GetLength(1); colone++)
            {
                //stocker les valeurs des lignes
                x = tableau[3, colone];
                y = tableau[2, colone];
                z = tableau[1, colone];
                w = tableau[0, colone];

                //changer l'ordre des numéros
                bas = ChangerOrdre(x, y, z, w);

                //redonner le nouvel ordre des nombres
                tableau[0, colone] = bas[3];
                tableau[1, colone] = bas[2];
                tableau[2, colone] = bas[1];
                tableau[3, colone] = bas[0];
            }
            return tableau;  //retourner le tableau complet avec les numéros != 0 en bas
        }

        //fonction déplacer les chiffres en haut
        static int[,] Haut(int[,] tableau)
        {
            int x, y, z, w;             //variable de position
            int[] haut = new int[4];

            //Passer dans chaques colones pour stocker les valeur des lignes et les manipuler
            for (int colone = 0; colone < tableau.GetLength(1); colone++)
            {
                //stocker les valeurs des lignes
                x = tableau[0, colone];
                y = tableau[1, colone];
                z = tableau[2, colone];
                w = tableau[3, colone];

                //changer l'ordre des numéros
                haut = ChangerOrdre(x, y, z, w);   //haut[] veut dire qu'on parle d'une case en particulier,  pour tout le tableau on ne met pas [].

                //redonner le nouvel ordre des nombres
                tableau[0, colone] = haut[0];
                tableau[1, colone] = haut[1];
                tableau[2, colone] = haut[2];
                tableau[3, colone] = haut[3];

            }
            //retourner le tableau complet avec les numéros != 0 en haut
            return tableau;

        }

        //fonction déplacer les chiffres à droite
        static int[,] Droite(int[,] tableau)
        {
            int x, y, z, w;                 //variable de position
            int[] droite = new int[4];

            // Passer dans chaques lignes pour stocker les valeur des colones et les manipuler
            for (int ligne = 0; ligne < tableau.GetLength(0); ligne++)
            {
                //stocker les valeurs des colones
                x = tableau[ligne, 3];
                y = tableau[ligne, 2];
                z = tableau[ligne, 1];
                w = tableau[ligne, 0];

                //changer l'ordre des numéros
                droite = ChangerOrdre(x, y, z, w);

                //redonner le nouvel ordre des nombres
                tableau[ligne, 0] = droite[3];
                tableau[ligne, 1] = droite[2];
                tableau[ligne, 2] = droite[1];
                tableau[ligne, 3] = droite[0];
            }
            //retourner le tableau complet avec les numéros != 0 à droite
            return tableau;

        }

        //fonction déplacer les chiffres à gauche
        static int[,] Gauche(int[,] tableau)
        {
            int x, y, z, w;                 //variable de position
            int[] gauche = new int[4];

            //Passer dans chaques lignes pour stocker les valeur des colones et les manipuler
            for (int ligne = 0; ligne < tableau.GetLength(0); ligne++)
            {
                x = tableau[ligne, 0];
                y = tableau[ligne, 1];
                z = tableau[ligne, 2];
                w = tableau[ligne, 3];

                //changer l'ordre des numéros
                gauche = ChangerOrdre(x, y, z, w);

                //redonner le nouvel ordre des nombres
                tableau[ligne, 0] = gauche[0];
                tableau[ligne, 1] = gauche[1];
                tableau[ligne, 2] = gauche[2];
                tableau[ligne, 3] = gauche[3];
            }
            //retourner le tableau complet avec les numéros != 0 à gauche
            return tableau;

        }


        //Fonction qui change l'ordre des nombres à gauche
        static int[] ChangerOrdre(int nb0, int nb1, int nb2, int nb3)
        {

            //interchanger deux valeurs numérique si un 0 est présent dans les valeurs
            if (nb2 == 0 && nb3 > 0)
            {
                nb2 = nb3;
                nb3 = 0;
                controleMouvements = true; //controler si le mouvements a eu lieu
            }

            if (nb1 == 0 && nb2 > 0)
            {
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
                controleMouvements = true; //controler si le mouvements a eu lieu
            }

            if (nb0 == 0 && nb1 > 0)
            {
                nb0 = nb1;
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
                controleMouvements = true; //controler si le mouvements a eu lieu
            }

            //fusionner les tuiles si elles ont les memes valeurs 
            if (nb0 == nb1 && nb0 != 0)
            {
                nb0 = nb0 + nb1; // +=nb1
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
                score += nb0; //calcule du score
                controleMouvements = true; //controle si le mouvements de la fusion a eu lieu
            }
            if (nb1 == nb2 && nb1 != 0)
            {
                nb1 = nb1 + nb2;
                nb2 = nb3;
                nb3 = 0;
                score += nb1;  //calcule du score
                controleMouvements = true; //controle si le mouvements de la fusion a eu lieu
            }
            if (nb2 == nb3 && nb2 != 0)
            {
                nb2 = nb2 + nb3;
                nb3 = 0;
                score += nb2;  //calcule du score
                controleMouvements = true; //controle si le mouvements de la fusion a eu lieu
            }

            //nouveau tableu contenant le (ou les) 0 dans la (ou les) dernière position
            int[] i = { nb0, nb1, nb2, nb3 };
            return i;
        }

        //fonction générer un nombre aléatoire dans le tableau
        static void Aleatoire(int[,] tableau)
        {
            int ligne = tableau.GetLength(0);   //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1);  //longueur de la dimmension y du tableau

            int aleatoireLigne = random.Next(0, 4);  //ligne aléatoire du tableau
            int aleatoireColone = random.Next(0, 4);  //colone aléatoire du tableau 
            int nombreAleatoire = random.Next(0, 10);  //généré un nombre aléatoire

            //met un chiffre aléatoire uniquement s'il ecrase un 0
            if (tableau[aleatoireLigne, aleatoireColone] == 0)
            {

                //choix d'afficher un 2 ou un 4 avec 90% et 10% de chance
                if (nombreAleatoire == 9)
                {
                    tableau[aleatoireLigne, aleatoireColone] = 4;         //affiche un 4 dans le tableau
                }
                else
                {
                    tableau[aleatoireLigne, aleatoireColone] = 2;         //affiche un 2 dans le tableau
                }
            }

            //le chiffre écrasé n'est pas un 0 alors on recommence au début de la fonction
            else
            {
                Aleatoire(tableau);
            }
        }

        //méthode qui controle si deux nombre sont identique
        static bool ControlePerdu(int nb0, int nb1, int nb2, int nb3)
        {
            if (nb0 == nb1)
            {
                return true;
            }
            else if (nb1 == nb2)
            {
                return true;
            }
            else if (nb2 == nb3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Fonction booléenne qui controle s'il reste un 0 dans le tableau ou si il y a un chiffre a 2028 ou s'il ont a perdu la game (plus de mouvements possible)
        static bool Controle(int[,] tableau)
        {
            int ligne = tableau.GetLength(0);  //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1);  //longueur de la dimmension y du tableau

            //controle si on a gagner: s'il y a un 2048 dans les tuiles
            while (!gagner)
            {
                gagner = controleGagner(tableau);
                if (gagner)
                {
                    Console.WriteLine("Bravo vous avez gagné! Appyer sur C pour quitter ou sur les flèches pour continuer à jouer");
                }
                break;
            }



            // Parcourir les lignes du tableau
            for (int i = 0; i < ligne; i++)
            {
                // Parcourir les colonnes du tableau
                for (int j = 0; j < colone; j++)
                {
                    if (tableau[i, j] == 0)
                    {
                        return true;   //s'il reste un 0 dans le tableau, on retourne true

                    }
                }
                //controle si deux nombres dans une ligne sont identique
                if (ControlePerdu(tableau[i, 0], tableau[i, 1], tableau[i, 2], tableau[i, 3]))
                {
                    return true; //permet de continuer à jouer
                }
                //contrôle si deux nombres sont identique dans une colone
                if (ControlePerdu(tableau[0, i], tableau[1, i], tableau[2, i], tableau[3, i]))
                {
                    return true; //permet de continuer à jouer
                }
            }
            //on retourne false quand il n'y a plus de 0 dans le tableau ou deux nombres identiques contigües qui se suivent
            //on a perdu la game
            Console.WriteLine("Vous avez malheureusmeent perdu!");
            return false;
        }

        //Fonction pour afficher un tableau 2D
        static void AfficherTableau(int[,] tableau)
        {
            int ligne = tableau.GetLength(0);  //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1); //longueur de la dimmension y du tableau

            Console.Clear();
            Console.WriteLine("******************************");

            // Parcourir les lignes du tableau
            for (int i = 0; i < ligne; i++)
            {
                // Parcourir les colonnes du tableau
                for (int j = 0; j < colone; j++)
                {
                    // Mettre le chiffre en couleur
                    Console.ForegroundColor = Couleur(tableau[i, j]);
                    // Afficher la valeur à la position (i, j)
                    Console.Write(tableau[i, j] + "\t");
                    // Mettre par défaut la couleur du texte (en blanc)
                    Console.ResetColor();
                }

                // Passer à la ligne suivante après chaque ligne du tableau
                Console.WriteLine("\n");
              
            }

            //Afficher le score
            Console.WriteLine("Le score est de : " + score.ToString());
            Console.WriteLine("******************************");
        }

        //Méthode pour afficher les chiffres de la grilles en couleur
        static ConsoleColor Couleur (int chiffre)
        {
            switch (chiffre)
            {
                case 2:
                    return ConsoleColor.Green;
                case 4: 
                    return ConsoleColor.Blue;
                case 8:
                    return ConsoleColor.Red;
                case 16:
                    return ConsoleColor.Magenta;
                case 32:
                    return ConsoleColor.Yellow;
                case 64:
                    return ConsoleColor.Cyan;
                case 128:
                    return ConsoleColor.DarkBlue;
                case 256:
                    return ConsoleColor.Gray;
                case 512:
                    return ConsoleColor.DarkRed;
                case 1024:
                    return ConsoleColor.DarkGreen;
                case 2048:
                    return ConsoleColor.DarkYellow;
                default:
                    return ConsoleColor.White;
            }
        }


    }
}
