using System;

namespace ParkerViewer.Abstractions.Dtos
{
    public class LeadDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Region { get; set; }

        public string Sity { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Flat { get; set; }

        public bool Agreed { get; set; }

        public bool Payed { get; set; }

        public bool Deleivered { get; set; }

        public int[] Pens { get; set; }

        public DateTime CreatingDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string DeliveryMethod { get; set; }

        public string PayMethod { get; set; }

        public string Comment { get; set; }
    }
}