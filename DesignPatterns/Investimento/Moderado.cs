﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investimento
{
    public class Moderado : IInvestimento
    {
        public double Investe(Conta conta)
        {
            bool altoRetorno = new Random().Next(101) > 50;

            return altoRetorno ? conta.Valor * 0.025 : conta.Valor * 0.007;
        }
    }
}
