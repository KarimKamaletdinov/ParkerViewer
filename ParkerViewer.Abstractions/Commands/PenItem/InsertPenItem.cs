using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands.PenItem
{
    public class InsertPenItem : Command
    {
        public PenItemDto PenItem {get; set; }
    }
}