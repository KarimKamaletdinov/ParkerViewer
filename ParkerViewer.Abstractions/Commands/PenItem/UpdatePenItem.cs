using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands.PenItem
{
    public class UpdatePenItem : Command
    {
        public PenItemDto PenItem { get; set; }
    }
}
