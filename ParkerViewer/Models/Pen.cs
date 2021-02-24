using System;

namespace ParkerViewer.Models
{
    public class Pen
    {
        private int _id;
        private string _collection;
        private int _price;
        private string _name;
        private string _detailColor;
        private string _writingType;
        private bool _goldPen;
        private bool _engraving;
        private bool _forMan;
        private bool _forWoman;
        
        public int Id
        {
            get => _id;
            set => _id = value <= 0 ? throw new Exception("PenId can not be 0 or " +
                "negative") : value;
        }

        public string Collection
        {
            get => _collection;
            set => _collection = value ?? throw new Exception("Collection " +
                    "can not be 0 or negative");
        }

        public int Price
        {
            get => _price;
            set => _price = value < 0 ? throw new Exception("Price can not" +
                " be negative") : value;
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new Exception("Name can not" +
                " be null");
        }

        public string DetailColor
        {
            get => _detailColor;
            set => _detailColor = value != "золотой" && value != "серебряный" ?
                throw new Exception("DetailColor can be only \"золотой\" or " +
                "\"серебряный\"") : value;
        }

        public string WritingType
        {
            get => _writingType;
            set => _writingType = value != "шариковый" && value != "роллер"
                || value == "перьевой" ? throw new Exception("WritingType can be only " +
                    "\"шариковый\", \"роллер\" or \"перьевой\"") : value;
        }

        public bool GoldPen
        {
            get => _goldPen;
            set => _goldPen = value;
        }

        public bool Engraving
        {
            get => _engraving;
            set => _engraving = value;
        }

        public bool ForMan
        {
            get => _forMan;
            set => _forMan = value;
        }

        public bool ForWoman
        {
            get => _forWoman;
            set => _forWoman = value;
        }
    }
}