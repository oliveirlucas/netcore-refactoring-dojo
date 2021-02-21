using MeuAcerto.Selecao.KataGildedRose.Reference;
using MeuAcerto.Selecao.KataGildedRose.Repository;
using MeuAcerto.Selecao.KataGildedRose.Repository.Interface;
using MeuAcerto.Selecao.KataGildedRose.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MeuAcerto.Selecao.KataGildedRose.Testes
{
    public class GildedRoseTest
    {
		IItensRepository _itensRepository = new ItensRepository();
		IGildedRose _gildedRose = new GildedRose();

		[Fact]
        public void DadoQueNaoPoderaExistirQualidadeNegativa()
        {
            IList<Item> itens = Itens();

			for (var i = 0; i < 31; i++)
			{
				itens = _gildedRose.AtualizarSituacaoDoItem(i, itens);
			}
			Assert.DoesNotContain(itens, i => i.Qualidade < 0);
		}

		[Fact]
		public void DadoQueNaoPodeExistirItensComQualidadeMaiorQue50()
        {
			IList<Item> itens = Itens();

			for (var i = 0; i < 31; i++)
			{
				itens = _gildedRose.AtualizarSituacaoDoItem(i, itens);
			}
			var obterItensEspecificos = itens.Where(i => i.Nome != TipoItem.DENTE_DO_TARRASQUE);
			Assert.DoesNotContain(obterItensEspecificos, i => i.Qualidade > 50);
		}

		[Fact]
		public void DadoQueOItemDenteDoTarrasqueNaoPoderaSerAtualizado()
        {
			IList<Item> itens = Itens();
			IList<Item> itensRepository = _itensRepository.ObterItens();
			for (var i = 0; i < 31; i++)
			{
				itens = _gildedRose.AtualizarSituacaoDoItem(i, itens);
			}
			var denteDoTarrasque = itens.Where(i => i.Nome == TipoItem.DENTE_DO_TARRASQUE);
			var denteDoTarrasqueRepository = itensRepository.Where(i => i.Nome == TipoItem.DENTE_DO_TARRASQUE);

			Assert.Contains(denteDoTarrasque, i => i.Qualidade == denteDoTarrasqueRepository.Select(d => d.Qualidade).FirstOrDefault());
			Assert.Contains(denteDoTarrasque, i => i.PrazoParaVenda == denteDoTarrasqueRepository.Select(d => d.PrazoParaVenda).FirstOrDefault());
		}

		[Fact]
		public void DadoQueOsIngressosEstaoComPrazoMenorQueZeroEntaoQualidadeDeveSerIgualAZero()
        {
			IList<Item> itens = Itens();
			IList<Item> itensRepository = _itensRepository.ObterItens();
			for (var i = 0; i < 31; i++)
			{
				itens = _gildedRose.AtualizarSituacaoDoItem(i, itens);
			}

			var ingressos = itens.Where(i => i.Nome == TipoItem.INGRESSOS_PARA_O_CONCERTO_DO_TURISAS);
			Assert.DoesNotContain(ingressos, i => i.PrazoParaVenda <= 0 && i.Qualidade > 0);
		}

        private IList<Item> Itens()
        {
			return new List<Item>
			{
				new Item
				{
					Nome = "Corselete +5 DEX",
					PrazoParaVenda = 10,
					Qualidade = 20
				},
				new Item
				{
					Nome = "Queijo Brie Envelhecido",
					PrazoParaVenda = 2,
					Qualidade = 0
				},
				new Item
				{
					Nome = "Elixir do Mangusto",
					PrazoParaVenda = 5,
					Qualidade = 7

				},
				new Item
				{
					Nome = "Dente do Tarrasque",
					PrazoParaVenda = 0,
					Qualidade = 80
				},
				new Item
				{
					Nome = "Dente do Tarrasque",
					PrazoParaVenda = -1,
					Qualidade = 80
				},
				new Item
				{
					Nome = "Ingressos para o concerto do Turisas",
					PrazoParaVenda = 15,
					Qualidade = 20
				},
				new Item
				{
					Nome = "Ingressos para o concerto do Turisas",
					PrazoParaVenda = 10,
					Qualidade = 49
				},
				new Item
				{
					Nome = "Ingressos para o concerto do Turisas",
					PrazoParaVenda = 5,
					Qualidade = 49
				},
				new Item
				{
					Nome = "Bolo de Mana Conjurado",
					PrazoParaVenda = 3,
					Qualidade = 6
				}
			};
		}
    }
}
