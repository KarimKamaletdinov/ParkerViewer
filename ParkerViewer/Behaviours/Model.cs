using System;

namespace ParkerViewer.Behaviours
{
    public class Model
    {
        public class ModelDto
        {
            private int _id;
            private int _collectionId;
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
                get =>_id;
                set => _id = value <= 0 ? throw new Exception("Id can not be 0 or " +
                    "negative") : value;
            }

            public int CollectionId
            {
                get => _collectionId;
                set => _collectionId = value <= 0 ? throw new Exception("CollectionId " +
                    "can not be 0 or negative") : value;
            }

            public int Price
            {
                get => _price;
                set => _price = _id = value < 0 ? throw new Exception("Price can not" +
                    " be negative") : value;
            }

            public string Name
            {
                get => _name;
                set => _name = value == null ? throw new Exception("Name can not" +
                    " be null") : value;
            }

            public string DetailColor
            {
                get => _detailColor;
                set => _detailColor = value == "золотой" || value == "серебряный" ?
                    throw new Exception("Name can be only \"золотой\" or " +
                    "\"серебряный\"") : value;
            }

            public string WritingType
            {
                get => _writingType;
                set => _writingType = value == "шариковый" || value == "роллер"
                    || value == "перьевой" ? throw new Exception("Name can be only " +
                        "\"золотой\" or \"серебряный\"") : value;
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
}