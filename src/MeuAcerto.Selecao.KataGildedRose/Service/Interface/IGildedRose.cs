using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose.Service.Interface
{
    public interface IGildedRose
    {
        IList<Item> AtualizarSituacaoDoItem(int i, IList<Item> itens);
    }
}
