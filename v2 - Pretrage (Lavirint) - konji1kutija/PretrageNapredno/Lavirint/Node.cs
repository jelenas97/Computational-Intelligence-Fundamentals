using System;
using System.Collections.Generic;
using System.Text;

namespace Lavirint
{
    public class Node
    {
        public int markI, markJ;
        private static int[,] moves = new int[,] {{2,1},{2,-1},{-2,1},{-2,-1},{-1,2},{-1,-2},{1,2},{1,-2} };

        public Node(int markI, int markJ)
        {
            this.markI = markI;
            this.markJ = markJ;
        }

        private bool validCoords(int markI, int markJ,bool skakac)
        {
            // TODO 2: Implementirati logiku za validna/nevalidna stanja iz zabranu prolaska kroz zidove
           
             
            if (markI < 0 || markI >= Main.lavirint.brojVrsta)
            {
                return false;
            }

            if (markJ < 0 || markJ >= Main.lavirint.brojKolona)
            {
                return false;
            }

            if (Main.lavirint.polja[markI, markJ] == 1)
            {
                return false;
            }

            if (skakac)
            {
                //gore-desno
                if ((markI - this.markI == -2) && (markJ - this.markJ == 1))
                {   // Ako su oba polja ili makar jedno iznad mene zablokirana, odustani
                    if (((Main.lavirint.polja[this.markI - 1, this.markJ] == 1) || (Main.lavirint.polja[this.markI - 2, this.markJ] == 1))
                                && ((Main.lavirint.polja[this.markI, this.markJ + 1] == 1) || (Main.lavirint.polja[this.markI - 1, this.markJ + 1] == 1)))
                    {
                        return false;
                    }
                }
                // gore-levo
                if ((markI - this.markI == -2) && (markJ - this.markJ == -1))
                {  
                    if (((Main.lavirint.polja[this.markI - 1, this.markJ] == 1) || (Main.lavirint.polja[this.markI - 2, this.markJ] == 1))
                                && ((Main.lavirint.polja[this.markI, this.markJ - 1] == 1) || (Main.lavirint.polja[this.markI - 1, this.markJ - 1] == 1)))
                    {
                        return false;
                    }
                }
                //desno-gore
                if ((markI - this.markI == -1) && (markJ - this.markJ == 2))
                {   
                    if (((Main.lavirint.polja[this.markI, this.markJ + 1] == 1) || (Main.lavirint.polja[this.markI, this.markJ + 2] == 1))
                                && ((Main.lavirint.polja[this.markI - 1, this.markJ] == 1) || (Main.lavirint.polja[this.markI - 1, this.markJ + 1] == 1)))
                    {
                        return false;
                    }
                }
                // desno-dole
                if ((markI - this.markI == 1) && (markJ - this.markJ == 2))
                {  
                    if (((Main.lavirint.polja[this.markI, this.markJ + 1] == 1) || (Main.lavirint.polja[this.markI, this.markJ + 2] == 1))
                                && ((Main.lavirint.polja[this.markI + 1, this.markJ] == 1) || (Main.lavirint.polja[this.markI + 1, this.markJ + 1] == 1)))
                    {
                        return false;
                    }
                }
                //dole-desno
                if ((markI - this.markI == 2) && (markJ - this.markJ == 1))
                {  
                    if (((Main.lavirint.polja[this.markI + 1, this.markJ] == 1) || (Main.lavirint.polja[this.markI + 2, this.markJ] == 1))
                                && ((Main.lavirint.polja[this.markI, this.markJ + 1] == 1) || (Main.lavirint.polja[this.markI + 1, this.markJ + 1] == 1)))
                    {
                        return false;
                    }
                }
                //dole-levo
                if ((markI - this.markI == 2) && (markJ - this.markJ == -1))
                {   
                    if (((Main.lavirint.polja[this.markI + 1, this.markJ] == 1) || (Main.lavirint.polja[this.markI + 2, this.markJ] == 1))
                                && ((Main.lavirint.polja[this.markI, this.markJ - 1] == 1) || (Main.lavirint.polja[this.markI + 1, this.markJ - 1] == 1)))
                    {
                        return false;
                    }
                }
                // levo-dole
                if ((markI - this.markI == 1) && (markJ - this.markJ == -2))
                {   
                    if (((Main.lavirint.polja[this.markI, this.markJ - 1] == 1) || (Main.lavirint.polja[this.markI, this.markJ - 2] == 1))
                                && ((Main.lavirint.polja[this.markI + 1, this.markJ] == 1) || (Main.lavirint.polja[this.markI + 1, this.markJ - 1] == 1)))
                    {
                        return false;
                    }
                }
                // levo-gore
                if ((markI - this.markI == -1) && (markJ - this.markJ == -2))
                {   
                    if (((Main.lavirint.polja[this.markI, this.markJ - 1] == 1) || (Main.lavirint.polja[this.markI, this.markJ - 2] == 1))
                        && ((Main.lavirint.polja[this.markI - 1, this.markJ] == 1) || (Main.lavirint.polja[this.markI - 1, this.markJ - 1] == 1)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public List<Node> getLinkedNodes()
        {
            // TODO 1: Implementirati metodu tako da odredjuje dozvoljeno kretanje u lavirintu.
            List<Node> nextNodes = new List<Node>();

            for (int i = 0; i < Node.moves.GetLength(0); i++)
            {
                int newI = Node.moves[i, 0] + this.markI;
                int newJ = Node.moves[i, 1] + this.markJ;

                if (this.validCoords(newI, newJ,false))
                {
                    nextNodes.Add(new Node(newI, newJ));
                }
            }
            return nextNodes;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Node node = (Node)obj;
            return this.markI == node.markI && this.markJ == node.markJ;
        }

       
    }
}
