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