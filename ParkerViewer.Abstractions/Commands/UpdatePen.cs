using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands
{
    public class UpdatePen : Command
    {
        public PenDto Pen { get; set; }
    }
}