using System;
using System.Collections.Generic;
using System.Text;

namespace Lavirint
{
    public class Node
    {
        
        private static int[,] moves = new int[,] { {1,0} , {0,1} , {-1,0} , {0,-1} , {1,1} , {-1,-1} };
        public int markI, markJ;

        public Node(int markI, int markJ)
        {
            this.markI = markI;
            this.markJ = markJ;
        }

        private bool validCoords(int markI, int markJ)
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

                if (this.validCoords(newI, newJ))
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
