using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands
{
    public class InsertPenCommand : Command
    {
        public PenDto Pen {get; set; }
    }
}