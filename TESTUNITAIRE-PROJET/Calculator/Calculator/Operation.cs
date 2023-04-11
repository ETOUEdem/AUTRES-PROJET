using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Operation : IOperation
    {
        public int Multiplication(int x, int y)
        {
           return x*y;
        }

        public int Sum(int x, int y)
        {
          return x+y;
        }
    }
}
