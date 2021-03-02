using System;

namespace ParkerViewer.PensPage
{
    public class Filter
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public char Sign { get; set; }

        public bool Execute(string fieldName, string fieldValue)
        {
            if (FieldName != fieldName)
            {
                return false;
            }

            if (DateTime.TryParse(FieldValue, out var a) && DateTime.TryParse(fieldValue, out var b))
            {
                switch (Sign)
                {
                    case '>':
                        return a < b;
                    case '<':
                        return a > b;
                    case '=':
                        return a == b;
                }
            }

            switch (Sign)
            {
                case '>':
                    return int.Parse(FieldValue) < int.Parse(fieldValue);
                case '<':
                    return int.Parse(FieldValue) > int.Parse(fieldValue);
                case '=':
                    return FieldValue == fieldValue;
                case '?':
                    return fieldValue.Contains(FieldValue);
                default:
                    return false;
            }
        }
    }
}