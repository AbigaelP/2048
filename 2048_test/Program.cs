using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Initialisé le tableau
            int[,] tableau2D = new int[4, 4];

            // Afficher le tableau 2D
            AfficherTableau2D(tableau2D);

            Console.ReadKey();
        }


        // Méthode pour afficher un tableau 2D
        static void AfficherTableau2D(int[,] tableau)
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
