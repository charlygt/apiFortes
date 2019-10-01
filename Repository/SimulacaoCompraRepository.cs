using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class SimulacaoCompraRepository : BaseRepository<SimulacaoCompra>, ISimulacaoCompraRepository
    {
    
        public SimulacaoCompraRepository(Context context) : base(context)
        {
            
        }


        public void AddSimulacao(SimulacaoCompra simulacao) => Add(simulacao);

        public SimulacaoCompra Find(int id) =>  GetById(id);

        

        public ICollection<SimulacaoCompra> Obter() => GetAll();

        public List<ParcelasCompra> ObterComParcelas()
        {
            return null;
        }
    }
}
