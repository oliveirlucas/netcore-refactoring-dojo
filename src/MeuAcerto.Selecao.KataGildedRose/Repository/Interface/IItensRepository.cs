using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose.Repository.Interface
{
    public interface IItensRepository
    {
        IList<Item> ObterItens();
    }
}
