using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Helper;

namespace Business
{
    public interface ISimulacaoCompraBusiness
    {
        JsonMessage AddSimulacao(SimulacaoCompra simulacao);
        ICollection<SimulacaoCompra> Obter();
        SimulacaoCompra Find(int id);
        List<ParcelasCompra> ObterParcelas(int id);
    }
}