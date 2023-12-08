﻿using System;
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
     * Description: Déplacer des nombres positionner aléatoirement dans un tableau dans 4 directions distinctes.
     */
    internal class Program
    {
        //définir l'aléatoire en dehors du void main pour gagner de la rapidité
        static Random random = new Random();

        //déclarer le score
        static int score = 0;

        static void Main(string[] args)
        {
            //Initialisé le tableau 4 par 4
            int[,] tableau2D = new int[4, 4];

            //Créer une variable booléenne initialisée à true
            bool jeu = true;

            //Mettre deux nombre aléatoire
            for (int p =0; p <=1; p++)
            {
                aleatoire(tableau2D);
            }

            //Une boucle while qui continue tant qu'il reste des 0 dans le tableau et que les variables booléennes restent sur true
            while (jeu && controle(tableau2D) == true)
            {
                //Détecter sur quelle touche l'utilisateur appuie
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                // Créer un switch pour les flèches directionnelles
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        //Fonction du mouvements des tuiles vers le haut
                        tableau2D = haut(tableau2D);
                        //Générer un nombre aléatoire après le mouvement
                        aleatoire(tableau2D);
                        break;
                    case ConsoleKey.DownArrow:
                        //Fonction du mouvements des tuiles vers le bas
                        tableau2D = bas(tableau2D);
                        //Générer un nombre aléatoire
                        aleatoire(tableau2D);
                        break;
                    case ConsoleKey.LeftArrow:
                        //Fonction du mouvements des tuiles vers la gauche
                       tableau2D = gauche(tableau2D);
                        //Générer un nombre aléatoire
                        aleatoire(tableau2D);
                        break;
                    case ConsoleKey.RightArrow:
                        //Fonction du mouvements des tuiles vers la droite
                        tableau2D = droite(tableau2D);
                        //Générer un nombre aléatoire
                        aleatoire(tableau2D);
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
        

        //Fonction déplacer les chiffres (tuiles) vers le bas
        static int[,] bas(int[,] tableau)
        {
            int x, y, z, w;             //variable de position
            int[] bas = new int[4];     

            //Passer dans chaques colones pour stocker les valeur des lignes et les manipuler
            for(int colone = 0; colone < tableau.GetLength(1); colone++) 
            {
                //stocker les valeurs des lignes
                x = tableau[3, colone];
                y = tableau[2, colone];
                z = tableau[1, colone];
                w = tableau[0, colone];
                
                //changer l'ordre des numéros
                bas = changerOrdre(x, y, z, w);

                //redonner le nouvel ordre des nombres
                tableau[0, colone] = bas[3];
                tableau[1, colone] = bas[2];
                tableau[2, colone] = bas[1];
                tableau[3, colone] = bas[0];
            }
            return tableau;  //retourner le tableau complet avec les numéros != 0 en bas
        }

        //fonction déplacer les chiffres en haut
        static int[,] haut(int[,] tableau)
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
                haut = changerOrdre(x, y, z, w);   //haut[] veut dire qu'on parle d'une case en particulier,  pour tout le tableau on ne met pas [].

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
        static int[,] droite(int[,] tableau)
        {
            int x, y, z, w;                 //variable de position
            int[] droite = new int[4];

            //Passer dans chaques lignes pour stocker les valeur des colones et les manipuler
            for (int ligne = 0; ligne < tableau.GetLength(0); ligne++)
            {
                //stocker les valeurs des colones
                x = tableau[ligne, 3];
                y = tableau[ligne, 2];
                z = tableau[ligne, 1];
                w = tableau[ligne, 0];

                //changer l'ordre des numéros
                droite = changerOrdre(x, y, z, w);

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
        static int[,] gauche(int[,] tableau)
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
                gauche = changerOrdre(x, y, z, w);

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
        static int[] changerOrdre(int nb0, int nb1, int nb2, int nb3)
        {
           
            //interchanger deux valeurs numérique si un 0 est présent dans les valeurs
            if (nb2 == 0 && nb3 > 0)
            {
                nb2 = nb3;
                nb3 = 0;
            }

            if (nb1 == 0 && nb2 > 0)
            {
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
            }

            if (nb0 == 0 && nb1 > 0)
            {
                nb0 = nb1;
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
            }

            //fusionner les tuiles si elles ont les memes valeurs 
            if (nb0 == nb1 && nb0 != 0)
            { 
                nb0 = nb0+nb1; // +=nb1
                nb1 = nb2;
                nb2 = nb3;
                nb3 = 0;
                score += nb0; //calcule du score
            }
            if (nb1 == nb2 && nb1!= 0)
            {
                nb1 = nb1 + nb2;
                nb2 = nb3;
                nb3 = 0;
                score += nb1;  //calcule du score
            }
            if(nb2 == nb3 && nb2 != 0)
            {
                nb2 = nb2 + nb3;
                nb3 = 0;
                score += nb2;  //calcule du score
            }

            //nouveau tableu contenant le (ou les) 0 dans la (ou les) dernière position
            int[] i = { nb0, nb1, nb2, nb3 };
            return i;
        }

        //fonction générer un nombre aléatoire dans le tableau
        static void aleatoire(int[,] tableau)
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
               
                Console.Clear();
                Console.WriteLine("******************************");

                AfficherTableau(tableau);

                //Afficher le score
                Console.WriteLine("Le score est de : " + score.ToString());
                Console.WriteLine("******************************");
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
            int ligne = tableau.GetLength(0);  //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1);  //longueur de la dimmension y du tableau

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
            }
            //on retourne false quand il n'y a plus de 0 dans le tableau
            Console.WriteLine("Le tableau est plein");
            return false;
        }

        //Fonction pour afficher un tableau 2D
        static void AfficherTableau(int[,] tableau)
        {
            int ligne = tableau.GetLength(0);  //longueur de la dimmension x du tableau
            int colone = tableau.GetLength(1); //longueur de la dimmension y du tableau

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
                Console.WriteLine();
            }
        }

    }
}
