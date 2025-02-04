﻿using Impostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Impostos
{
    public class ICPP : TemplateImposto
    {
        public ICPP() : base() { }
        public ICPP(IImposto outroImposto) : base(outroImposto) { }

        public override bool AplicaMaximoImposto(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }

        public override double MaximoValor(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        public override double MinimoValor(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }
}
