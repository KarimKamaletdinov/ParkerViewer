using System;

namespace ParkerViewer.Models
{
    public class Lead
    {
        private int _id;
        private string _customerName;
        private int[] _pens;
        private DateTime _creatingDate;
        private DateTime _deliveryDate;
        private string _deliveryMethod;
        private string _payMethod;
        private string _comment;
        private bool _payed;
        private bool _deleivered;
        private bool _agreed;
        private string _region;
        private string _sity;
        private string _street;
        private string _house;
        private string _flat;

        public int Id
        {
            get => _id;
            set => _id = value > 0 ? value : throw new Exception("Id can not be 0 or negative");
        }

        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value ?? throw new NullReferenceException();

        }

        public string Region
        {
            get => _region;
            set => _region = value ?? throw new NullReferenceException();
        }

        public string Sity
        {
            get => _sity;
            set => _sity = value ?? throw new NullReferenceException();
        }

        public string Street
        {
            get => _street;
            set => _street = value ?? throw new NullReferenceException();
        }

        public string House
        {
            get => _house;
            set => _house = value ?? throw new NullReferenceException();
        }

        public string Flat
        {
            get => _flat;
            set => _flat = value ?? "";
        }

        public bool Agreed
        {
            get => _agreed;
            set => _agreed = value;
        }

        public bool Payed
        {
            get => _payed;
            set => _payed = value;
        }

        public bool Deleivered
        {
            get => _deleivered;
            set => _deleivered = value;
        }

        public int[] Pens
        {
            get => _pens;
            set => _pens = value;
        }

        public DateTime CreatingDate
        {
            get => _creatingDate;
            set => _creatingDate = value;
        }

        public DateTime DeliveryDate
        {
            get => _deliveryDate;
            set => _deliveryDate = value;
        }

        public string DeliveryMethod
        {
            get => _deliveryMethod;
            set => _deliveryMethod = value;
        }

        public string PayMethod
        {
            get => _payMethod;
            set => _payMethod = value;
        }

        public string Comment
        {
            get => _comment;
            set => _comment = value;
        }

        public int FullPrice => throw new NotImplementedException();
    }
}