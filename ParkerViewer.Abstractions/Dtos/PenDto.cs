namespace ParkerViewer.Abstractions.Dtos
{
    public class PenDto
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string DetailColor { get; set; }
        public string WritingType { get; set; }
        public bool GoldPen { get; set; }
        public bool Engraving { get; set; }
        public bool ForMan { get; set; }
        public bool ForWoman { get; set; }
    }
}
