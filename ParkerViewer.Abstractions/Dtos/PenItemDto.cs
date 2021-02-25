namespace ParkerViewer.Abstractions.Dtos
{
    public class PenItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public int Stock { get; set; }
        public string Engraving { get; set; }
        public bool Broken { get; set; }
    }
}
