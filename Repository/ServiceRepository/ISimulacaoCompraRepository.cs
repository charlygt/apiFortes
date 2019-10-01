using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository
{
    public interface ISimulacaoCompraRepository
    {
        void AddSimulacao(SimulacaoCompra simulacao);
        ICollection<SimulacaoCompra> Obter();
        SimulacaoCompra Find(int id);
        List<ParcelasCompra> ObterComParcelas();
    }
}