using Domain.Entity;
using Domain.Helper;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class SimulacaoCompraBusiness : ISimulacaoCompraBusiness
    {
        private readonly ISimulacaoCompraRepository _simulacaoRepository;
        private readonly JsonMessage _json;

        public SimulacaoCompraBusiness(ISimulacaoCompraRepository simulacaoRepository, JsonMessage json)
        {
            _simulacaoRepository = simulacaoRepository;
            _json = json;
        }

        public JsonMessage AddSimulacao(SimulacaoCompra simulacao)
        {
            try
            {
                _simulacaoRepository.AddSimulacao(simulacao);
                _json.Type = "success";
                _json.Title = "Simulação armazenada com sucesso!";
                _json.Message = "Para ter acesso aos detalhes da simulação, dirija-se ao menu Simulaçoes.";
                return _json;
            }
            catch (Exception ex)
            {
                _json.Type = "error";
                _json.Title = "Opa, houve um erro ao salvar a simulação, tente novamente mais tarde!";
                _json.Message = ex.Message;
                return _json;

            }

        }

        public SimulacaoCompra Find(int id) => _simulacaoRepository.Find(id);


        public ICollection<SimulacaoCompra> Obter() => _simulacaoRepository.Obter();

        public List<ParcelasCompra> ObterParcelas(int id) => _simulacaoRepository.ObterComParcelas();
        
    }
}
