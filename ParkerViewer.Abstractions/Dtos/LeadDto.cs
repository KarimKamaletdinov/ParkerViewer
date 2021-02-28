using System;

namespace ParkerViewer.Abstractions.Dtos
{
    public class LeadDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CostumerAddress { get; set; }

        public string Status { get; set; }

        public int[] Pens { get; set; }

        public DateTime CreatingDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string DeliveryMethod { get; set; }

        public string PayMethod { get; set; }

        public string Comment { get; set; }
    }
}