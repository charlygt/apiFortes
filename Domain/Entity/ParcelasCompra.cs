using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class ParcelasCompra
    {
        public int Id { get; set; }

        public int Parcela { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal JurosAplicado { get; set; }
        public DateTime DataVencimento { get; set; }

        public int SimulacaoCompraId { get; set; }

    }
}
