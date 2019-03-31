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
        public int kutijaBlue;
        public int kutijaOrange;
        public HashSet<int> pokupioPlave;
        public HashSet<int> pokupioOrange;
        public bool plaveUspesno;


        public int Count { get; }

        public State()
        {
            kutijaBlue = 3;
            kutijaOrange = 2;
            pokupioPlave = new HashSet<int>();
            pokupioOrange = new HashSet<int>();


        }
        public State sledeceStanje(Node node)
        {
            State rez = new State();
            rez.node = node;
            rez.parent = this;
            rez.cost = this.cost + 1;
            rez.level = this.level + 1;
            rez.kutijaBlue = this.kutijaBlue;
            rez.kutijaOrange = this.kutijaOrange;
            rez.plaveUspesno = this.plaveUspesno;

            foreach (int i in this.pokupioPlave)
            {
                rez.pokupioPlave.Add(i);
            }

            foreach (int i in this.pokupioOrange)
            {
                rez.pokupioOrange.Add(i);
            }

            return rez;
        }


        public List<State> mogucaSledecaStanja()
        {

            if (this.kutijaBlue != 0 && Main.lavirint.polja[node.markI, node.markJ] == 4)
            {
                //this.kutija = true;
                if (!this.pokupioPlave.Contains(node.markI + 1000 * node.markJ))
                {
                    
                        this.kutijaBlue--;
                        pokupioPlave.Add(node.markI + 1000 * node.markJ);
                    
                    
                   
                }

            }

            if (this.kutijaBlue == 0)

            {
                this.plaveUspesno = true;
            }

            if (plaveUspesno == true)
            {

                if (this.kutijaOrange != 0 && Main.lavirint.polja[node.markI, node.markJ] == 5)
                {
                    if (!this.pokupioOrange.Contains(node.markI + 10000 * node.markJ))
                    {

                        this.kutijaOrange--;
                        pokupioOrange.Add(node.markI + 10000 * node.markJ);

                    }
                }
            }
           

            List<State> rez = new List<State>();
            foreach (Node nextNode in this.node.getLinkedNodes())
            {
                rez.Add(this.sledeceStanje(nextNode));
            }
            return rez;
        }

        public bool isKrajnjeStanje()
        {
            return Main.krajnjiNode.markI == node.markI && Main.krajnjiNode.markJ ==node.markJ && this.kutijaBlue == 0 && this.kutijaOrange==0;
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

            return false;
        }


        public override int GetHashCode()
        {
            int hashValue = 0;
            
                hashValue += this.kutijaBlue * 1000 ;
                hashValue += this.kutijaOrange * 10000;


            hashValue += 100 * node.markI + node.markJ;
            return hashValue;
        }
    }
}
