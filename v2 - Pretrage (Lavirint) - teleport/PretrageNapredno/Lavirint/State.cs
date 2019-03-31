using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

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
            List<State> lista = new List<State>();

            if (Main.lavirint.polja[node.markI, node.markJ] == 4)
            {
                this.kutija = true;

            }     

            foreach (Node nextNode in this.node.getLinkedNodes())
            {
                lista.Add(this.sledeceStanje(nextNode));
            }


            if (Main.lavirint.polja[node.markI, node.markJ] == 5)
            {
                foreach (Node s in Main.portals)
                {
                    if (s.markI == node.markI && s.markJ == node.markJ)
                        continue;
                   
                    lista.Add(this.sledeceStanje(s));
                }

            }

    
            return lista;
        }



        public override int GetHashCode()
        {
            int hashValue = 0;
            if (this.kutija)
                hashValue += 1000;
          

            hashValue += 100 * node.markI + node.markJ;
            return hashValue;
        }

        public bool isKrajnjeStanje()
        {
            
            return Main.krajnjiNode.markI == this.node.markI && Main.krajnjiNode.markJ == this.node.markJ && this.kutija ;

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

        public bool cirkularnaPutanja()
        {
            // TODO 3: proveriti da li trenutno stanje odgovara poziciji koja je vec vidjena u grani pretrazivanja
            State t = this.parent;

            while (t != null)
            {
                if (t.node.Equals(this.node))
                {
                    return true;
                }

                t = t.parent;
            }
            
            return false;
        }
    }
}
