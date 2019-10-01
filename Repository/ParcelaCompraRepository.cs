using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class ParcelaCompraRepository : BaseRepository<ParcelasCompra>, IParcelaCompraRepository
    {

        public ParcelaCompraRepository(Context context) : base(context)
        {

        }
        
        public ICollection<ParcelasCompra> Obter(int id) => GetAll(x => x.SimulacaoCompraId == id);


    }
}
