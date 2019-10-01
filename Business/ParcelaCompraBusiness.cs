using Domain.Entity;
using Domain.Helper;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class ParcelaCompraBusiness : IParcelaCompraBusiness
    {
        private readonly IParcelaCompraRepository _parcelaRepository;


        public ParcelaCompraBusiness(IParcelaCompraRepository parcelaRepository)
        {
            _parcelaRepository = parcelaRepository;

        }

        public ICollection<ParcelasCompra> Obter(int id) => _parcelaRepository.Obter(id);


    }
}
