using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_test
{
    internal class Program
    {
        //définir l'aléatoire en dehors du void main pour gagner de la rapidité
        static Random random = new Random();
        static void Main(string[] args)
        {
            //Initialisé le tableau
            int[,] tableau2D = new int[4, 4];

            // Créer une variable booléenne initialisée à true
            bool jeu = true;

            //mettre deux nombre aléatoire
            for (int p =0; p <=1; p++)
            {
                aleatoire(tableau2D);
            }

            // Une boucle while qui continue tant qu'il reste des 0 dans le tableau
            while (jeu && controle(tableau2D) == true)
            {
                //Détecter sur quelle touche l'utilisateur appuie
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                // Créer un switch pour les flèches directionnelles
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        //ici fonction du mouvemnets des tuiles
                        //ici fonction généré 1 nombre éléatoire
                        break;
                    case ConsoleKey.DownArrow:
                        //ici fonction du mouvemnets des tuiles
                        //ici fonction généré 1 nombre éléatoire
                        break;
                    case ConsoleKey.LeftArrow:
                        //ici fonction du mouvemnets des tuiles
                        //ici fonction généré 1 nombre éléatoire
                        break;
                    case ConsoleKey.RightArrow:
                        //ici fonction du mouvemnets des tuiles
                        //ici fonction généré 1 nombre éléatoire
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
            }
            
            Console.ReadKey();
        }

        //fonction générer un nombre aléatoire dans le tableau
        static void aleatoire(int[,] tableau)
        {
            int ligne = tableau.GetLength(0);
            int colone = tableau.GetLength(1);

            int aleatoireLigne = random.Next(0, 4);
            int aleatoireColone = random.Next(0, 4);
            int nombreAleatoire = random.Next(0, 10);

            //met un chiffre aléatoire uniquement s'il ecrase un 0
            if (tableau[aleatoireLigne, aleatoireColone] == 0)
            {
                if (nombreAleatoire == 9)
                {
                    tableau[aleatoireLigne, aleatoireColone] = 4;
                }
                else
                {
                    tableau[aleatoireLigne, aleatoireColone] = 2;
                }
               

                Console.Clear();
                Console.WriteLine();

                AfficherTableau(tableau);

                

                Console.WriteLine();
            }

            //le chiffre écrasé n'est pas un 0 alors on recommence au début de la fonction
            else
            {
               aleatoire(tableau);
            }
        }

        // Fonction booléenne qui controle s'il reste un 0 dans le tableau
        static bool controle(int[,] tableau)
        {
            int ligne = tableau.GetLength(0);
            int colone = tableau.GetLength(1);

            // Parcourir les lignes du tableau
            for (int i = 0; i < ligne; i++)
            {
                // Parcourir les colonnes du tableau
                for (int j = 0; j < colone; j++)
                {
                    if (tableau[i, j] == 0)
                    {
                        return true;            //il reste un 0 dans le tableau
                    }
                }
            }
            //retourne false quand il n'y a plus de 0 dans le tableau
            Console.WriteLine("Le tableau est plein");
            return false;
        }

        // Fonction pour afficher un tableau 2D
        static void AfficherTableau(int[,] tableau)
        {
            int ligne = tableau.GetLength(0);
            int colone = tableau.GetLength(1);

            // Parcourir les lignes du tableau
            for (int i = 0; i < ligne; i++)
            {
                // Parcourir les colonnes du tableau
                for (int j = 0; j < colone; j++)
                {
                    // Afficher la valeur à la position (i, j)
                    Console.Write(tableau[i, j] + "\t");
                }

                // Passer à la ligne suivante après chaque ligne du tableau
                Console.WriteLine();
            }
        }

    }
}
