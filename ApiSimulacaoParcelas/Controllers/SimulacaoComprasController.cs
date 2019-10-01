using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Repository;
using Business;
using System.Web.Http.Results;
using Domain.Helper;
using Microsoft.AspNetCore.Cors;

namespace ApiSimulacaoParcelas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulacaoComprasController : ControllerBase
    {
        private readonly ISimulacaoCompraBusiness _business;
        private readonly IParcelaCompraBusiness _businessParcela;
        public SimulacaoComprasController(ISimulacaoCompraBusiness business, IParcelaCompraBusiness businessParcela)
        {
            _business = business;
            _businessParcela = businessParcela;
        }
        // GET: api/SimulacaoCompras
        [HttpGet]
        public IEnumerable<SimulacaoCompra> Get()
        {
            return _business.Obter();
        }
        // POST: api/SimulacaoCompras
        [HttpPost]
        public JsonMessage Post([FromBody] SimulacaoCompra simulacaoCompra)
        {
            return _business.AddSimulacao(simulacaoCompra);
        }

        [HttpGet("{id}")]
        public List<ParcelasCompra> Get(int id)
        {
            return _businessParcela.Obter(id).ToList();
        }
        
    }
}