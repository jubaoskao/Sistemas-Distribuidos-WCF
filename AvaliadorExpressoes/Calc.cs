using System;
using System.Collections;
using System.Collections.Generic;

namespace AvaliadorExpressoes
{
    /// <summary>
    /// Classe da calculadora
    /// </summary>
    public class Calc
    {

        /// <summary>
        /// Construtor
        /// </summary>
        public Calc()
        {
        }

        /// <summary>
        /// Analisa a expressão e retorna verdadeiro ou falso se está ou não correta
        /// </summary>
        /// <param name="expr">Expressão infixa a analisar</param>
        /// <returns>Se é válida ou não</returns>
        public bool Analisar(string expr)
        {
            Pilha S = new Pilha(expr.Length);
            foreach (char c in expr)
            {
                if (c == '(' || c == '[' || c == '{') S.Push(c);
                if (c == ')' || c == ']' || c == '}')
                {
                    if (S.Vazia()) return false;
                    char p = (char)S.Pop();
                    if (p == '(' && c != ')') return false;
                    if (p == '[' && c != ']') return false;
                    if (p == '{' && c != '}') return false;
                }
            }

            // Passou por tudo e expressão é válida
            return S.Vazia();
        }

        /// <summary>
        /// Converte uma expressão infixa em pósfixa
        /// </summary>
        /// <param name="expr">Expressão infixa a converter</param>
        /// <returns>A expressão pósfixa</returns>
        public string Converter(string expressao)
        {
            Pilha p = new Pilha(expressao.Length);
            string posfixa = string.Empty;
            int pr;
            char aux;

            expressao = expressao.Replace("{", "(").Replace("[", "(");
            expressao = expressao.Replace("}", ")").Replace("]", ")");

            //Implementar

            foreach(char c in expressao)
            {
                if(c >='A' && c <= 'Z' || c >= 'a' && c <= 'z' || c >= '0' && c <= '9' || c == '$')
                {
                    posfixa += c;
                }

                if(c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
                {
                    pr = Prioridade(c);

                    while(!p.Vazia() && Prioridade(Convert.ToChar(p.Topo())) >= pr)
                    {
                        posfixa += p.Pop();
                    }
                    p.Push(c);
                }

                if (c == '(')
                    p.Push(c);

                if(c == ')')
                {
                    aux = Convert.ToChar(p.Pop());

                    while(aux != '(')
                    {
                        posfixa += aux;
                        aux = Convert.ToChar(p.Pop());
                    }
                }
            }

            while (!p.Vazia())
            {
                posfixa += p.Pop();
            }

            return posfixa;
        }

        public Hashtable ObterVariaveis(string expressao)
        {
            Hashtable hash = new Hashtable();

            foreach (var item in expressao)
            {
                if ((item >= 'A' && item <= 'Z') || (item >= 'a' && item <= 'z') || (item >= '0' && item <= '9') || item == '$')
                    hash[item] = 0;

            }
            return hash;
        }

        private int Prioridade(char c)
        {
            switch (c)
            {
                case '(': return 1;
                case '+':
                case '-': return 2;
                case '*':
                case '/': return 3;
                case '^': return 4;
            }
            return 0;
        }

        /// <summary>
        /// Calcula o valor de uma expressão pósfixa
        /// </summary>
        /// <param name="posfixa"> A expressão pósfixa</param>
        /// <returns> O resultado da conta</returns>
        public double Calcular(string posfixa, Hashtable vars)
        {
            //Implementar
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
            Pilha s = new Pilha(posfixa.Length);
            double x, y;
            double res;

            
        foreach(char c in posfixa)
        {

            if(c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
            {
                if (c >= '0' && c <= '9')
                {
                    s.Push(Convert.ToDouble(c.ToString()));
                }
                else {
                    s.Push(Convert.ToDouble(vars[c.ToString()]));
                }
            }
            else
            {
                if (c == '$')
                {
                    s.Push(Convert.ToDouble(s.Pop()) + Math.Cos(Convert.ToDouble(c)));
                }

                else {
                y = Convert.ToDouble(s.Pop());
                x = Convert.ToDouble(s.Pop());
                

                if (c == '+')
                {
                    s.Push(svc.SumValue(x, y));
                }

                else if (c == '-')
                {
                    s.Push(svc.SubtractValue(x, y));
                }

                else if (c == '*')
                {
                    s.Push(svc.MultiValue(x, y));
                }

                else if (c == '/')
                {
                    s.Push(svc.DivValue(x, y));
                }

                else if (c == '^')
                {
                    s.Push(Math.Pow(x, y));
                }

               }
            }
        }

            res = Convert.ToDouble(s.Pop());

            return res;
        }

    }
}
