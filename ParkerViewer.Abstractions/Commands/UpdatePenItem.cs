using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands
{
    public class UpdatePenItem : Command
    {
        public PenItemDto PenItem { get; set; }
    }
}
