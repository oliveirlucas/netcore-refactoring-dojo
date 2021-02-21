using MeuAcerto.Selecao.KataGildedRose.Reference;
using MeuAcerto.Selecao.KataGildedRose.Service.Interface;
using System;
using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
    public class GildedRose : IGildedRose
    {

        public IList<Item> AtualizarSituacaoDoItem(int i, IList<Item> itens)
        {
            Console.WriteLine("-------- dia " + i + " --------");
            Console.WriteLine("Nome, PrazoParaVenda, Qualidade");
            for (var j = 0; j < itens.Count; j++)
            {
                Console.WriteLine(itens[j].Nome + ", " + itens[j].PrazoParaVenda + ", " + itens[j].Qualidade);
            }
            Console.WriteLine("");

            foreach (var item in itens)
            {
                AtualizarPrazoVenda(item);
                AtualizarQualidade(item);
            }

            return itens;
        }

        private void AtualizarQualidade(Item item)
        {
            if (item.Nome != TipoItem.QUEIJO_BRIE_ENVELHECIDO &&
                item.Nome != TipoItem.INGRESSOS_PARA_O_CONCERTO_DO_TURISAS &&
                item.Nome != TipoItem.DENTE_DO_TARRASQUE &&
                item.Nome != TipoItem.BOLO_DE_MANA_CONJURADO &&
                item.Qualidade > 0)
            {
                item.Qualidade = item.Qualidade - 1;

                if(item.PrazoParaVenda < 0)
                {
                    item.Qualidade = item.Qualidade - 1;
                }
            } 
            else
            {
                AtualizarQueijoBrieEnvelhecido(item);
                AtualizarIngressosParaOConcertoDoTurisas(item);
                AtualizaBoloDeManaConjurado(item);
            }
        }

        private void AtualizarPrazoVenda(Item item)
        {
            if (item.Nome != TipoItem.DENTE_DO_TARRASQUE)
            {
                item.PrazoParaVenda = item.PrazoParaVenda - 1;
            }
        }

        private void AtualizarQueijoBrieEnvelhecido(Item item)
        {
            if(item.Nome == TipoItem.QUEIJO_BRIE_ENVELHECIDO &&
                item.Qualidade < 50)
            {
                item.Qualidade = item.Qualidade + 1;
            }
        }
        private void AtualizarIngressosParaOConcertoDoTurisas(Item item)
        {
            if (item.Nome == TipoItem.INGRESSOS_PARA_O_CONCERTO_DO_TURISAS)
            {
                if (item.PrazoParaVenda > 0)
                {
                    if(item.Qualidade < 50)
                    {
                        item.Qualidade = item.Qualidade + 1;

                        if (item.PrazoParaVenda <= 10 && item.Qualidade < 50)
                        {
                            item.Qualidade = item.Qualidade + 1;
                        }

                        if (item.PrazoParaVenda <= 5 && item.Qualidade < 50)
                        {
                            item.Qualidade = item.Qualidade + 1;
                        }
                    }
                }
                else
                {
                    item.Qualidade = item.Qualidade - item.Qualidade;
                }
            }
        }
        private void AtualizaBoloDeManaConjurado(Item item)
        {
            if (item.Nome == TipoItem.BOLO_DE_MANA_CONJURADO && item.Qualidade > 0)
            {
                item.Qualidade = item.Qualidade - 2;
            }
        }
    }
}
