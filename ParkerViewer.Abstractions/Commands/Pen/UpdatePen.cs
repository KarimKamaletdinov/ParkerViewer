using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands.Pen
{
    public class UpdatePen : Command
    {
        public PenDto Pen { get; set; }
    }
}