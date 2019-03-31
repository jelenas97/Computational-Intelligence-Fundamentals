using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Lavirint
{
    class AStarSearch
    {
        public State search(State pocetnoStanje)
        {
            // TODO 5.1: Implementirati algoritam vodjene pretrage A*
            List<State> zaObradu = new List<State>();
            Hashtable predjeniPut = new Hashtable();

            zaObradu.Add(pocetnoStanje);

            while (zaObradu.Count > 0)
            {
                State naObradi = getBest(zaObradu);

                if (!predjeniPut.ContainsKey(naObradi.GetHashCode()))
                {
                    Main.allSearchStates.Add(naObradi);

                    if (naObradi.isKrajnjeStanje())
                    {
                        return naObradi;
                    }

                    predjeniPut.Add(naObradi.GetHashCode(), null);
                    List<State> mogucaStanja = naObradi.mogucaSledecaStanja();
                    foreach (State s in mogucaStanja)
                    {
                        zaObradu.Add(s);
                    }


                }

                zaObradu.Remove(naObradi);

            }
                return null;
        }

        
        public double heuristicFunction(State s)
        {
            // TODO 5.2: Implementirati heuristicku funkciju (funkcija odredjuje rastojanje)
            return Math.Sqrt(Math.Pow(s.node.markI - Main.krajnjiNode.markI, 2) + Math.Pow(s.node.markJ - Main.krajnjiNode.markJ, 2)) + s.cost;

        }


        public State getBest(List<State> stanja)
        {
            State best = null;
            double min = Double.MaxValue;

            foreach (State s in stanja)
            {
                double h = heuristicFunction(s);
                if (h < min)
                {
                    min = h;
                    best = s;
                }

            }

            return best;

        }
    }
}
