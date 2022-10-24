using System;

namespace Projetmorpion
{
    class Program
    {
        public static void ShowTab(string[,] Tableau, int tour)
        {
            Console.Clear();
            Console.WriteLine("Tour N°" + tour);
            Console.WriteLine("        1    2    3   ");
            Console.WriteLine(" ");
            Console.WriteLine("  A     {0} |  {1}  | {2}  ", Tableau[0, 0], Tableau[0, 1], Tableau[0, 2]);
            Console.WriteLine("      ----|-----|----   ");
            Console.WriteLine("  B     {0} |  {1}  | {2}  ", Tableau[1, 0], Tableau[1, 1], Tableau[1, 2]);
            Console.WriteLine("      ----|-----|----   ");
            Console.WriteLine("  C     {0} |  {1}  | {2}  ", Tableau[2, 0], Tableau[2, 1], Tableau[2, 2]);
        }
        public static int VerifWin(string[,]Tableau)
        {   //Verif ligne hau ---
            if (Tableau[0, 0] == "X" & Tableau[0, 0] == Tableau[0, 1] & Tableau[0, 1] == Tableau[0, 2])
                return 1;
            //Verif ligne \
            else if (Tableau[0, 0] == "X" & Tableau[0, 0] == Tableau[1, 1] & Tableau[1, 1] == Tableau[2, 2])
                return 2;
            //Verif ligne gauche |
            else if (Tableau[0, 0] == "X" & Tableau[0, 0] == Tableau[1, 0] & Tableau[1, 0] == Tableau[2, 0])
                return 3;
            //Verif ligne mid ---
            else if (Tableau[1, 0] == "X" & Tableau[1, 0] == Tableau[1, 1] & Tableau[1, 1] == Tableau[1, 2])
                return 4;
            //Verif ligne bas ---
            else if (Tableau[2, 0] == "X" & Tableau[2, 0] == Tableau[2, 1] & Tableau[2, 1] == Tableau[2, 2])
                return 5;
            //Verif ligne /
            else if (Tableau[2, 0] == "X" & Tableau[2, 0] == Tableau[1, 1] & Tableau[1, 1] == Tableau[0, 2])
                return 6;
            //Verif ligne droite |
            else if (Tableau[0, 2] == "X" & Tableau[0, 2] == Tableau[1, 2] & Tableau[1, 2] == Tableau[2, 2])
                return 7;
            //Verif ligne mid |
            else if (Tableau[0, 1] == "X" & Tableau[0, 1] == Tableau[1, 1] & Tableau[1, 1] == Tableau[2, 1])
                return 8;
            else if (Tableau[0, 0] == "O" & Tableau[0, 0] == Tableau[0, 1] & Tableau[0, 1] == Tableau[0, 2])
                return -1;
            //Verif ligne \
            else if (Tableau[0, 0] == "O" & Tableau[0, 0] == Tableau[1, 1] & Tableau[1, 1] == Tableau[2, 2])
                return -2;
            //Verif ligne gauche |
            else if (Tableau[0, 0] == "O" & Tableau[0, 0] == Tableau[1, 0] & Tableau[1, 0] == Tableau[2, 0])
                return -3;
            //Verif ligne mid ---
            else if (Tableau[1, 0] == "O" & Tableau[1, 0] == Tableau[1, 1] & Tableau[1, 1] == Tableau[1, 2])
                return -4;
            //Verif ligne bas ---
            else if (Tableau[2, 0] == "O" & Tableau[2, 0] == Tableau[2, 1] & Tableau[2, 1] == Tableau[2, 2])
                return -5;
            //Verif ligne /
            else if (Tableau[2, 0] == "O" & Tableau[2, 0] == Tableau[1, 1] & Tableau[1, 1] == Tableau[0, 2])
                return -6;
            //Verif ligne droite |
            else if (Tableau[0, 2] == "O" & Tableau[0, 2] == Tableau[1, 2] & Tableau[1, 2] == Tableau[2, 2])
                return -7;
            //Verif ligne mid |
            else if (Tableau[0, 1] == "O" & Tableau[0, 1] == Tableau[1, 1] & Tableau[1, 1] == Tableau[2, 1])
                return -8;
            //Continue a jouer
            else return 0;
        }
        public static void VerifCaseLibre(string[,]Tableau, ref int colonne, ref int ligne)
        {
            bool trouve = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((Tableau[i, j] == "■") && (trouve == false))
                    { 
                    ligne = j;
                    colonne = i;
                    trouve = true;
                    }
                }
            }
        }
        public static void JouerCaseLibre(ref string[,] Tableau, ref int colonne, ref int ligne)
        {
            Tableau[colonne, ligne] = "O";
        }
        public static int CombiGangnanteDef(string[,]Tableau)
        {
            //ligne middle
            if (Tableau[1, 0] == "■" & Tableau[1, 1] == "X" & Tableau[1, 2] == "X" || 
                Tableau[1, 0] == "■" & Tableau[0, 0] == "X" & Tableau[2, 0] == "X")
                return 10;

            if (Tableau[1, 0] == "X" & Tableau[1, 1] == "■" & Tableau[1, 2] == "X" ||
                Tableau[0, 0] == "X" & Tableau[1, 1] == "■" & Tableau[2, 2] == "X" ||
                Tableau[0, 1] == "X" & Tableau[1, 1] == "■" & Tableau[2, 1] == "X" ||
                Tableau[0, 2] == "X" & Tableau[1, 1] == "■" & Tableau[2, 0] == "X")
                return 11;

            if (Tableau[1, 0] == "X" & Tableau[1, 1] == "X" & Tableau[1, 2] == "■" ||
                Tableau[2, 2] == "X" & Tableau[0, 2] == "X" & Tableau[1, 2] == "■")
                return 12;

            //ligne basse
            if (Tableau[2, 0] == "■" & Tableau[2, 1] == "X" & Tableau[2, 2] == "X" ||
                Tableau[2, 0] == "■" & Tableau[1, 0] == "X" & Tableau[0, 0] == "X" ||
                Tableau[2, 0] == "■" & Tableau[1, 1] == "X" & Tableau[0, 2] == "X")
                return 20;

            if (Tableau[2, 0] == "X" & Tableau[2, 1] == "■" & Tableau[2, 2] == "X" ||
                Tableau[0, 1] == "X" & Tableau[2, 1] == "■" & Tableau[1, 1] == "X")
                return 21;

            if (Tableau[2, 0] == "X" & Tableau[2, 1] == "X" & Tableau[2, 2] == "■" ||
                Tableau[0, 0] == "X" & Tableau[1, 1] == "X" & Tableau[2, 2] == "■" ||
                Tableau[0, 2] == "X" & Tableau[1, 2] == "X" & Tableau[2, 2] == "■")
                return 22;

            else return 0;
        }
        public static int CombiGangnanteAtt(string[,] Tableau)
        {
            if (Tableau[0, 0] == "O" & Tableau[0, 1] == "O" & Tableau[0, 2] == "■")
                return 1;
            //ligne middle
            if (Tableau[1, 0] == "■" & Tableau[1, 1] == "O" & Tableau[1, 2] == "O" ||
                Tableau[1, 0] == "■" & Tableau[0, 0] == "O" & Tableau[2, 0] == "O")
                return 10;

            if (Tableau[1, 0] == "O" & Tableau[1, 1] == "■" & Tableau[1, 2] == "O" ||
                Tableau[0, 0] == "O" & Tableau[1, 1] == "■" & Tableau[2, 2] == "O" ||
                Tableau[0, 1] == "O" & Tableau[1, 1] == "■" & Tableau[2, 1] == "O" ||
                Tableau[0, 2] == "O" & Tableau[1, 1] == "■" & Tableau[2, 0] == "O")
                return 11;

            if (Tableau[1, 0] == "O" & Tableau[1, 1] == "O" & Tableau[1, 2] == "■" ||
                Tableau[2, 2] == "O" & Tableau[0, 2] == "O" & Tableau[1, 2] == "■")
                return 12;

            //ligne basse
            if (Tableau[2, 0] == "■" & Tableau[2, 1] == "O" & Tableau[2, 2] == "O" ||
                Tableau[2, 0] == "■" & Tableau[1, 0] == "O" & Tableau[0, 0] == "O" ||
                Tableau[2, 0] == "■" & Tableau[1, 1] == "O" & Tableau[0, 2] == "O")
                return 20;

            if (Tableau[2, 0] == "O" & Tableau[2, 1] == "■" & Tableau[2, 2] == "O" ||
                Tableau[0, 1] == "O" & Tableau[2, 1] == "■" & Tableau[1, 1] == "O")
                return 21;

            if (Tableau[2, 0] == "O" & Tableau[2, 1] == "O" & Tableau[2, 2] == "■" ||
                Tableau[0, 0] == "O" & Tableau[1, 1] == "O" & Tableau[2, 2] == "■" ||
                Tableau[0, 2] == "O" & Tableau[1, 2] == "O" & Tableau[2, 2] == "■")
                return 22;

            else return 0;
        }
        public static void SysJeuJcJ(string NomJ1, string NomJ2, ref string [,] Tableau)
        {
            string PosJ1;
            string PosJ2;
            int tour = 0;
            int erreur = 0;
            while (tour < 9 & VerifWin(Tableau) == 0)
            {
                ShowTab(Tableau, tour);
                if (tour % 2 == 0)
                {
                    do
                    {
                        if (erreur == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Occupé, veuillez choisir un autre emplacement");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        else if (erreur == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Coordonées invalide, veuillez choisir un emplacement dans la grille");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(NomJ1 + ", c'est a votre tour, vous etes les X :");
                        Console.ForegroundColor = ConsoleColor.White;
                        PosJ1 = (Console.ReadLine());
                        switch (PosJ1)
                        {
                            case "A1":
                                if (Tableau[0, 0] != "X" & Tableau[0, 0] != "O")
                                    Tableau[0, 0] = "X";
                                else erreur = 1;
                                break;
                            case "A2":
                                if (Tableau[0, 1] != "X" & Tableau[0, 1] != "O")
                                    Tableau[0, 1] = "X";
                                else erreur = 1;
                                break;
                            case "A3":
                                if (Tableau[0, 2] != "X" & Tableau[0, 2] != "O")
                                    Tableau[0, 2] = "X";
                                else erreur = 1;
                                break;
                            case "B1":
                                if (Tableau[1, 0] != "X" & Tableau[1, 0] != "O")
                                    Tableau[1, 0] = "X";
                                else erreur = 1;
                                break;
                            case "B2":
                                if (Tableau[1, 1] != "X" & Tableau[1, 1] != "O")
                                    Tableau[1, 1] = "X";
                                else erreur = 1;
                                break;
                            case "B3":
                                if (Tableau[1, 2] != "X" & Tableau[1, 2] != "O")
                                    Tableau[1, 2] = "X";
                                else erreur = 1;
                                break;
                            case "C1":
                                if (Tableau[2, 0] != "X" & Tableau[2, 0] != "O")
                                    Tableau[2, 0] = "X";
                                else erreur = 1;
                                break;
                            case "C2":
                                if (Tableau[2, 1] != "X" & Tableau[2, 1] != "O")
                                    Tableau[2, 1] = "X";
                                else erreur = 1;
                                break;
                            case "C3":
                                if (Tableau[2, 2] != "X" & Tableau[2, 2] != "O")
                                    Tableau[2, 2] = "X";
                                else erreur = 1;
                                break;
                            default:
                                erreur = 2;
                                break;
                        }
                        VerifWin(Tableau);
                    } while (erreur == 1 | erreur == 2);
                }
                else
                {
                    do
                    {
                        if (erreur == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Occupé, veuillez choisir un autre emplacement");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        else if (erreur == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Coordonées invalide, veuillez choisir un emplacement dans la grille");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(NomJ2 + ", c'est a votre tour, vous etes les O :");
                        Console.ForegroundColor = ConsoleColor.White;
                        PosJ2 = (Console.ReadLine());
                        switch (PosJ2)
                        {
                            case "A1":
                                if (Tableau[0, 0] != "X" & Tableau[0, 0] != "O")
                                    Tableau[0, 0] = "O";
                                else erreur = 1;
                                break;
                            case "A2":
                                if (Tableau[0, 1] != "X" & Tableau[0, 1] != "O")
                                    Tableau[0, 1] = "O";
                                else erreur = 1;
                                break;
                            case "A3":
                                if (Tableau[0, 2] != "X" & Tableau[0, 2] != "O")
                                    Tableau[0, 2] = "O";
                                else erreur = 1;
                                break;
                            case "B1":
                                if (Tableau[1, 0] != "X" & Tableau[1, 0] != "O")
                                    Tableau[1, 0] = "O";
                                else erreur = 1;
                                break;
                            case "B2":
                                if (Tableau[1, 1] != "X" & Tableau[1, 1] != "O")
                                    Tableau[1, 1] = "O";
                                else erreur = 1;
                                break;
                            case "B3":
                                if (Tableau[1, 2] != "X" & Tableau[1, 2] != "O")
                                    Tableau[1, 2] = "O";
                                else erreur = 1;
                                break;
                            case "C1":
                                if (Tableau[2, 0] != "X" & Tableau[2, 0] != "O")
                                    Tableau[2, 0] = "O";
                                else erreur = 1;
                                break;
                            case "C2":
                                if (Tableau[2, 1] != "X" & Tableau[2, 1] != "O")
                                    Tableau[2, 1] = "O";
                                else erreur = 1;
                                break;
                            case "C3":
                                if (Tableau[2, 2] != "X" & Tableau[2, 2] != "O")
                                    Tableau[2, 2] = "O";
                                else erreur = 1;
                                break;
                            default:
                                erreur = 2;
                                break;
                        }
                        VerifWin(Tableau);
                    } while (erreur == 1 | erreur == 2);
                }
                tour++; 
            }
            ShowTab(Tableau, tour);

            if (tour == 8 & VerifWin(Tableau) == 0)
                Console.WriteLine("Egalité");

            else if (VerifWin(Tableau) > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine(NomJ1 + " a gagné");
                Console.ForegroundColor = ConsoleColor.White;
            }
                

            else if (VerifWin(Tableau) < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine(NomJ1 + " a gagné");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void SysJeuBotRand (string NomJ1, ref string[,] Tableau)
        {
            string PosJ1;
            string PosJ2 = " ";
            int tour = 0;
            int erreur = 0;
            int ligne = 0;
            int colonne = 0;
            while (tour < 9 & VerifWin(Tableau) == 0)
            {
                ShowTab(Tableau, tour);
                #region Tourj1
                if (tour % 2 == 0)
                {
                    do
                    {
                        if (erreur == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Occupé, veuillez choisir un autre emplacement");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        else if (erreur == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Coordonées invalide, veuillez choisir un emplacement dans la grille");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(NomJ1 + ", c'est a votre tour, vous etes les X :");
                        Console.ForegroundColor = ConsoleColor.White;
                        PosJ1 = (Console.ReadLine());
                        switch (PosJ1)
                        {
                            case "A1":
                                if (Tableau[0, 0] != "X" & Tableau[0, 0] != "O")
                                    Tableau[0, 0] = "X";
                                else erreur = 1;
                                break;
                            case "A2":
                                if (Tableau[0, 1] != "X" & Tableau[0, 1] != "O")
                                    Tableau[0, 1] = "X";
                                else erreur = 1;
                                break;
                            case "A3":
                                if (Tableau[0, 2] != "X" & Tableau[0, 2] != "O")
                                    Tableau[0, 2] = "X";
                                else erreur = 1;
                                break;
                            case "B1":
                                if (Tableau[1, 0] != "X" & Tableau[1, 0] != "O")
                                    Tableau[1, 0] = "X";
                                else erreur = 1;
                                break;
                            case "B2":
                                if (Tableau[1, 1] != "X" & Tableau[1, 1] != "O")
                                    Tableau[1, 1] = "X";
                                else erreur = 1;
                                break;
                            case "B3":
                                if (Tableau[1, 2] != "X" & Tableau[1, 2] != "O")
                                    Tableau[1, 2] = "X";
                                else erreur = 1;
                                break;
                            case "C1":
                                if (Tableau[2, 0] != "X" & Tableau[2, 0] != "O")
                                    Tableau[2, 0] = "X";
                                else erreur = 1;
                                break;
                            case "C2":
                                if (Tableau[2, 1] != "X" & Tableau[2, 1] != "O")
                                    Tableau[2, 1] = "X";
                                else erreur = 1;
                                break;
                            case "C3":
                                if (Tableau[2, 2] != "X" & Tableau[2, 2] != "O")
                                    Tableau[2, 2] = "X";
                                else erreur = 1;
                                break;
                            default:
                                erreur = 2;
                                break;
                        }
                        VerifWin(Tableau);
                    } while (erreur == 1 | erreur == 2);
                }
                #endregion
                else
                {
                VerifCaseLibre(Tableau, ref ligne, ref colonne);
                JouerCaseLibre(ref Tableau, ref ligne, ref colonne);
                VerifWin(Tableau);
                }
                tour++;
            }
            ShowTab(Tableau, tour);

            if (tour == 8 & VerifWin(Tableau) == 0)
                Console.WriteLine("Egalité");

            else if (VerifWin(Tableau) > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine(NomJ1 + " a gagné");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (VerifWin(Tableau) < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine("L'ordinateur a gagné, la c chaud gro remet toi en questions mgl");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void SysJeuBotDef(string NomJ1, string NomJ2, ref string[,] Tableau)
        {
            string PosJ1;
            string PosJ2 = " ";
            int tour = 0;
            int erreur = 0;
            int ligne = 0;
            int colonne = 0;
            while (tour < 9 & VerifWin(Tableau) == 0)
            {
                ShowTab(Tableau, tour);
                #region Tourj1
                if (tour % 2 == 0)
                {
                    do
                    {
                        if (erreur == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Occupé, veuillez choisir un autre emplacement");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        else if (erreur == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Coordonées invalide, veuillez choisir un emplacement dans la grille");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(NomJ1 + ", c'est a votre tour, vous etes les X :");
                        Console.ForegroundColor = ConsoleColor.White;
                        PosJ1 = (Console.ReadLine());
                        switch (PosJ1)
                        {
                            case "A1":
                                if (Tableau[0, 0] != "X" & Tableau[0, 0] != "O")
                                    Tableau[0, 0] = "X";
                                else erreur = 1;
                                break;
                            case "A2":
                                if (Tableau[0, 1] != "X" & Tableau[0, 1] != "O")
                                    Tableau[0, 1] = "X";
                                else erreur = 1;
                                break;
                            case "A3":
                                if (Tableau[0, 2] != "X" & Tableau[0, 2] != "O")
                                    Tableau[0, 2] = "X";
                                else erreur = 1;
                                break;
                            case "B1":
                                if (Tableau[1, 0] != "X" & Tableau[1, 0] != "O")
                                    Tableau[1, 0] = "X";
                                else erreur = 1;
                                break;
                            case "B2":
                                if (Tableau[1, 1] != "X" & Tableau[1, 1] != "O")
                                    Tableau[1, 1] = "X";
                                else erreur = 1;
                                break;
                            case "B3":
                                if (Tableau[1, 2] != "X" & Tableau[1, 2] != "O")
                                    Tableau[1, 2] = "X";
                                else erreur = 1;
                                break;
                            case "C1":
                                if (Tableau[2, 0] != "X" & Tableau[2, 0] != "O")
                                    Tableau[2, 0] = "X";
                                else erreur = 1;
                                break;
                            case "C2":
                                if (Tableau[2, 1] != "X" & Tableau[2, 1] != "O")
                                    Tableau[2, 1] = "X";
                                else erreur = 1;
                                break;
                            case "C3":
                                if (Tableau[2, 2] != "X" & Tableau[2, 2] != "O")
                                    Tableau[2, 2] = "X";
                                else erreur = 1;
                                break;
                            default:
                                erreur = 2;
                                break;
                        }
                        VerifWin(Tableau);
                    } while (erreur == 1 | erreur == 2);
                }
                #endregion
                else
                {
                    CombiGangnanteDef(Tableau);
                    if (CombiGangnanteDef(Tableau) != 0)
                    { 
                        if (CombiGangnanteDef(Tableau) == 10)
                        {
                            Tableau[1, 0] = "O";
                        }
                        else if (CombiGangnanteDef(Tableau) == 11)
                        {
                            Tableau[1, 1] = "O";
                        }
                        else if (CombiGangnanteDef(Tableau) == 12)
                        {
                            Tableau[1, 2] = "O";
                        }
                        else if (CombiGangnanteDef(Tableau) == 20)
                        {
                            Tableau[2, 0] = "O";
                        }
                        else if (CombiGangnanteDef(Tableau) == 21)
                        {
                            Tableau[2, 1] = "O";
                        }
                        else if (CombiGangnanteDef(Tableau) == 22)
                        {
                            Tableau[2, 2] = "O";
                        }
                    }
                    else
                    {
                        VerifCaseLibre(Tableau, ref ligne, ref colonne);
                        JouerCaseLibre(ref Tableau, ref ligne, ref colonne);
                        VerifWin(Tableau);
                    }
                }
                tour++;
            }
            ShowTab(Tableau, tour);

            if (tour == 8 & VerifWin(Tableau) == 0)
                Console.WriteLine("Egalité");

            else if (VerifWin(Tableau) > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine(NomJ1 + " a gagné");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (VerifWin(Tableau) < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine("L'ordinateur a gagné, la c chaud gro remet toi en questions mgl");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void SysJeuBotAtt(string NomJ1, string NomJ2, ref string[,] Tableau)
        {
            string PosJ1;
            string PosJ2 = " ";
            int tour = 0;
            int erreur = 0;
            int ligne = 0;
            int colonne = 0;
            while (tour < 9 & VerifWin(Tableau) == 0)
            {
                ShowTab(Tableau, tour);
                #region Tourj1
                if (tour % 2 == 0)
                {
                    do
                    {
                        if (erreur == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Occupé, veuillez choisir un autre emplacement");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        else if (erreur == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ");
                            Console.WriteLine("Coordonées invalide, veuillez choisir un emplacement dans la grille");
                            Console.ForegroundColor = ConsoleColor.White;
                            erreur = 0;
                        }
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(NomJ1 + ", c'est a votre tour, vous etes les X :");
                        Console.ForegroundColor = ConsoleColor.White;
                        PosJ1 = (Console.ReadLine());
                        switch (PosJ1)
                        {
                            case "A1":
                                if (Tableau[0, 0] != "X" & Tableau[0, 0] != "O")
                                    Tableau[0, 0] = "X";
                                else erreur = 1;
                                break;
                            case "A2":
                                if (Tableau[0, 1] != "X" & Tableau[0, 1] != "O")
                                    Tableau[0, 1] = "X";
                                else erreur = 1;
                                break;
                            case "A3":
                                if (Tableau[0, 2] != "X" & Tableau[0, 2] != "O")
                                    Tableau[0, 2] = "X";
                                else erreur = 1;
                                break;
                            case "B1":
                                if (Tableau[1, 0] != "X" & Tableau[1, 0] != "O")
                                    Tableau[1, 0] = "X";
                                else erreur = 1;
                                break;
                            case "B2":
                                if (Tableau[1, 1] != "X" & Tableau[1, 1] != "O")
                                    Tableau[1, 1] = "X";
                                else erreur = 1;
                                break;
                            case "B3":
                                if (Tableau[1, 2] != "X" & Tableau[1, 2] != "O")
                                    Tableau[1, 2] = "X";
                                else erreur = 1;
                                break;
                            case "C1":
                                if (Tableau[2, 0] != "X" & Tableau[2, 0] != "O")
                                    Tableau[2, 0] = "X";
                                else erreur = 1;
                                break;
                            case "C2":
                                if (Tableau[2, 1] != "X" & Tableau[2, 1] != "O")
                                    Tableau[2, 1] = "X";
                                else erreur = 1;
                                break;
                            case "C3":
                                if (Tableau[2, 2] != "X" & Tableau[2, 2] != "O")
                                    Tableau[2, 2] = "X";
                                else erreur = 1;
                                break;
                            default:
                                erreur = 2;
                                break;
                        }
                        VerifWin(Tableau);
                    } while (erreur == 1 | erreur == 2);
                }
                #endregion
                else
                { 
                    CombiGangnanteAtt(Tableau);
                    if (CombiGangnanteAtt(Tableau) != 0)
                    {
                        if (CombiGangnanteAtt(Tableau) == 1)
                        {
                            Tableau[0, 2] = "O";
                        }
                        if (CombiGangnanteAtt(Tableau) == 10)
                        {
                            Tableau[1, 0] = "O";
                        }
                        else if (CombiGangnanteAtt(Tableau) == 11)
                        {
                            Tableau[1, 1] = "O";
                        }
                        else if (CombiGangnanteAtt(Tableau) == 12)
                        {
                            Tableau[1, 0] = "O";
                        }
                        else if (CombiGangnanteAtt(Tableau) == 20)
                        {
                            Tableau[2, 0] = "O";
                        }
                        else if (CombiGangnanteAtt(Tableau) == 21)
                        {
                            Tableau[2, 1] = "O";
                        }
                        else if (CombiGangnanteAtt(Tableau) == 22)
                        {
                            Tableau[2, 2] = "O";
                        }
                    }
                    else
                    {
                    if (Tableau[1, 1] == "■") Tableau[1, 1] = "O";
                        else {
                            VerifCaseLibre(Tableau, ref ligne, ref colonne);
                            JouerCaseLibre(ref Tableau, ref ligne, ref colonne);
                            VerifWin(Tableau);
                        }
                        
                    }
                }
                tour++;
            }
            ShowTab(Tableau, tour);

            if (tour == 8 & VerifWin(Tableau) == 0)
                Console.WriteLine("Egalité");

            else if (VerifWin(Tableau) > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine(NomJ1 + " a gagné");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (VerifWin(Tableau) < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine("L'ordinateur a gagné, la c chaud gro remet toi en questions mgl");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int reponseQ = 0;
            int choix = 0;
            string NomJ1;
            string NomJ2 = "ordinateur";
            do
            {
                Console.WriteLine("\nMenu : ");
                Console.WriteLine("\nAppuyez sur 1 pour jouer contre un joueur locale");
                Console.WriteLine("\nAppuyez sur 2 pour jouer contre un ordinateur aléatoire");
                Console.WriteLine("\nAppuyez sur 3 pour jouer contre un ordinateur défensif ");
                Console.WriteLine("\nAppuyez sur 4 pour jouer contre un ordinateur offensif");
                Console.WriteLine("\nAppuyez sur 5 pour quitter");
                choix = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Joueur N°1, entrez votre nom : ");
                NomJ1 = (Console.ReadLine());
                if (choix == 1) {
                    Console.WriteLine("Joueur N°2, entrez votre nom : ");
                    NomJ2 = (Console.ReadLine());
                }
                switch (choix)
                {
                    case 1:
                        do
                        {
                            string[,] Tableau = new string[3, 3] { { "■", "■", "■" }, { "■", "■", "■" }, { "■", "■", "■" } };
                            SysJeuJcJ(NomJ1, NomJ2, ref Tableau);
                            Console.WriteLine("Voulez vous recommencé ? 1 pour oui, peu importe pour revenir au menu");
                            reponseQ = int.Parse(Console.ReadLine());
                            Console.Clear();
                        } while (reponseQ == 1);
                        break;
                    case 2:
                        do
                        {
                            string[,] Tableau = new string[3, 3] { { "■", "■", "■" }, { "■", "■", "■" }, { "■", "■", "■" } };
                            SysJeuBotRand(NomJ1, ref Tableau);
                            Console.WriteLine("Voulez vous recommencé ? 1 pour oui, peu importe pour revenir au menu");
                            reponseQ = int.Parse(Console.ReadLine());
                            Console.Clear();
                        } while (reponseQ == 1);
                        break;
                    case 3:
                        do
                        {
                            string[,] Tableau = new string[3, 3] { { "■", "■", "■" }, { "■", "■", "■" }, { "■", "■", "■" } };
                            SysJeuBotDef(NomJ1, NomJ2, ref Tableau);
                            Console.WriteLine("Voulez vous recommencé ? 1 pour oui, peu importe pour revenir au menu");
                            reponseQ = int.Parse(Console.ReadLine());
                            Console.Clear();
                        } while (reponseQ == 1);
                        break;
                    case 4:
                        do
                        {
                            string[,] Tableau = new string[3, 3] { { "■", "■", "■" }, { "■", "■", "■" }, { "■", "■", "■" } };
                            SysJeuBotAtt(NomJ1, NomJ2, ref Tableau);
                            Console.WriteLine("Voulez vous recommencé ? 1 pour oui, peu importe pour revenir au menu");
                            reponseQ = int.Parse(Console.ReadLine());
                            Console.Clear();
                        } while (reponseQ == 1);
                        break;


                }
            } while (choix != 5); 
            
        }
    }
}

/*CombiGangnanteDef(Tableau);
if (CombiGangnanteDef(Tableau) == 1)
{
    Tableau[2, 1] = "O";
}
*/