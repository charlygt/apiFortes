using System.Collections.Generic;
using Domain.Entity;

namespace Business
{
    public interface IParcelaCompraBusiness
    {
        ICollection<ParcelasCompra> Obter(int id);
    }
}