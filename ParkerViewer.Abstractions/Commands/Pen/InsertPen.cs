using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands.Pen
{
    public class InsertPen : Command
    {
        public PenDto Pen {get; set; }
    }
}