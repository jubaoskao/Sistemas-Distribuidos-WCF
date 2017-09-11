using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvaliadorExpressoes
{
    public class Pilha
    {
        private object[] elementos;
        private int topo, max;

        public int Quantidade
        {
            get
            {
                return topo;
            }
        }

        public Pilha(int maximo)
        {
            this.max = maximo;
            elementos = new object[max];
            topo = 0;
        }

        public void Push(object x)
        {
            if (PilhaCheia())
                throw new Exception("Pilha Cheia");

            elementos[topo++] = x;
        }

        public object Pop()
        {
            if (Vazia())
                throw new Exception("Pilha Vazia");
            object x = Topo();
            elementos[--topo] = null;
            return x;

        }

        public bool Vazia()
        {
            return topo == 0;
        }

        private bool PilhaCheia()
        {
            return topo == max;
        }

        public object Topo()
        {
            if (Vazia())
                throw new Exception("Pilha Vazia");

            return elementos[topo - 1];
        }
    }
}
