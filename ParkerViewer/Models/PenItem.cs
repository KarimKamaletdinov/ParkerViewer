using System;

namespace ParkerViewer.Models
{
    public class PenItem
    {
        private int _id;
        private int _modelId;
        private string _name;
        private string _engraving;
        private bool _broken;
        private int _stock;

        public int Id
        {
            get => _id;
            set => _id = value <= 0 ? throw new Exception("PenId can not be 0 or " +
                "negative") : value;
        }

        public int ModelId
        {
            get => _modelId;
            set => _modelId = value < 0 ? throw new Exception("ModelId can not" +
                " be negative") : value;
        }

        public int Stock
        {
            get => _stock;
            set => _stock = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new Exception("Name can not" +
                " be null");
        }
        public string Engraving
        {
            get => _engraving;
            set => _engraving = value;
        }
        public bool Broken
        {
            get => _broken;
            set => _broken = value;
        }
    }
}