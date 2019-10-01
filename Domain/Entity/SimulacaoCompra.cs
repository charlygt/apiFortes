using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class SimulacaoCompra
    {
    
        public int Id { get; set; }

        public decimal ValorCompra { get; set; }
        public decimal ValorJuros { get; set; }
        public int QtdParcelas { get; set; }
        public DateTime DataCompra { get; set; }
        public virtual List<ParcelasCompra> ParcelasCompra { get; set; }
    }
}
