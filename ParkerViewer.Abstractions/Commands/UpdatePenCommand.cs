using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands
{
    public class UpdatePenCommand : Command
    {
        public PenDto Pen { get; set; }
    }
}