using System;
using System.Collections.Generic;
using System.Text;

namespace Lavirint
{
    public class State
    {
        public State parent;
        public Node node;
        public double cost;
        public int level;
        public bool kutija;

        public State sledeceStanje(Node node)
        {
            State rez = new State();
            rez.node = node;
            rez.parent = this;
            rez.cost = this.cost + 1;
            rez.level = this.level + 1;
            rez.kutija = this.kutija;

            return rez;
        }


        public List<State> mogucaSledecaStanja()
        {
            List<State> rez = new List<State>();

            if (Main.lavirint.polja[node.markI, node.markJ] == 4)
            {
                this.kutija = true;
            }

            foreach (Node nextNode in this.node.getLinkedNodes())
            {
                rez.Add(this.sledeceStanje(nextNode));
            }
            return rez;
        }

        public bool cirkularnaPutanja()
        {

            return false;
        }

        public bool isKrajnjeStanje()
        {
            return Main.krajnjiNode.markI == node.markI && Main.krajnjiNode.markJ == node.markJ && this.kutija;
        }

        public List<State> path()
        {
            List<State> putanja = new List<State>();
            State tt = this;
            while (tt != null)
            {
                putanja.Insert(0, tt);
                tt = tt.parent;
            }
            return putanja;
        }

        public override int GetHashCode()
        {
            int hashvalue = 0;

            if (this.kutija)
            {
                hashvalue += 1000;
            }

            hashvalue += 100 * node.markI + node.markJ;

            return hashvalue;
        }
    }
}
