using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
   public interface IOperation
    {
        int Multiplication(int x, int y);
        int Sum(int x, int y);
    }
}
