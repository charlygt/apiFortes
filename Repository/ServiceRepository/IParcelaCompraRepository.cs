using System.Collections.Generic;
using Domain.Entity;

namespace Repository
{
    public interface IParcelaCompraRepository
    {
        ICollection<ParcelasCompra> Obter(int id);
    }
}