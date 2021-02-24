using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands
{
    public class InsertPen : Command
    {
        public PenDto Pen {get; set; }
    }
}