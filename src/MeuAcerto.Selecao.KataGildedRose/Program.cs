using MeuAcerto.Selecao.KataGildedRose.Repository;
using MeuAcerto.Selecao.KataGildedRose.Repository.Interface;
using MeuAcerto.Selecao.KataGildedRose.Service.Interface;
using System;
using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
	class Program
	{
		public static void Main(string[] args)
		{
			IItensRepository _itensRepository = new ItensRepository();
			IGildedRose _gildedRose = new GildedRose();

			IList<Item> itens = _itensRepository.ObterItens();

			for (var i = 0; i < 31; i++)
			{
				itens = _gildedRose.AtualizarSituacaoDoItem(i,itens);
			}
		}
	}
}
