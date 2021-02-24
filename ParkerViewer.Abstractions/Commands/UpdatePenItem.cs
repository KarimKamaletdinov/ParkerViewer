using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands
{
    public class UpdatePenItem : Command
    {
        public PenItemDto Pen { get; set; }
    }
}