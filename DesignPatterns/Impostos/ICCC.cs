﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impostos
{
    public class ICCC : IImposto
    {
        public ICCC() : base() { }
        public ICCC(IImposto outroImposto) : base(outroImposto) { }

        public override double Calcula(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000)
            {
                return orcamento.Valor * 0.05;
            }

            if (orcamento.Valor >= 1000 && orcamento.Valor <= 3000)
            {
                return orcamento.Valor * 0.07;
            }

            return (orcamento.Valor * 0.08) + 30;
        }
    }
}
