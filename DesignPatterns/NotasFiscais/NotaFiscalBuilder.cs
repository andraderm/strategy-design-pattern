﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.NotasFiscais
{
    public class NotaFiscalBuilder
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public double ValorTotal { get; private set; }
        public double Impostos { get; private set; }
        public DateTime Data { get; private set; }
        public string Observacoes { get; private set; }
        public IList<ItemDaNota> TodosItens = new List<ItemDaNota>();

        private IList<AcaoAposGerarNota> todasAcoes;

        public NotaFiscalBuilder() 
        {
            Data = DateTime.Now;
            todasAcoes = new List<AcaoAposGerarNota>();
        }

        public void AdicionaAcao(AcaoAposGerarNota acao)
        {
            todasAcoes.Add(acao);
        }

        public NotaFiscalBuilder ParaEmpresa(string razaoSocial)
        {
            RazaoSocial = razaoSocial;
            return this;
        }

        public NotaFiscalBuilder ComCnpj(string cnpj)
        {
            Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder ComItem(ItemDaNota item)
        {
            TodosItens.Add(item);
            ValorTotal += item.Valor;
            Impostos += item.Valor * 0.05;

            return this;
        }

        public NotaFiscalBuilder ComObservacoes(string observacoes)
        {
            Observacoes = observacoes;
            return this;
        }

        public NotaFiscalBuilder NaData(DateTime data)
        {
            Data = data;
            return this;
        }

        public NotaFiscal Constroi()
        {
            NotaFiscal notaFiscal = new NotaFiscal(RazaoSocial, Cnpj, Data, ValorTotal, Impostos, TodosItens, Observacoes);

            foreach (AcaoAposGerarNota acao in todasAcoes)
            {
                acao.Executa(notaFiscal);
            }

            return notaFiscal;
        }
    }
}
