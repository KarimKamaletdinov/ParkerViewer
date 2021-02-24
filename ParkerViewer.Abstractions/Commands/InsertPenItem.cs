using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands
{
    public class InsertPenItem : Command
    {
        public PenItemDto PenItem {get; set; }
    }
}