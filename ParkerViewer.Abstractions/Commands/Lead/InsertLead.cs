using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands.Lead
{
    public class InsertLead : Command
    {
        public LeadDto Lead { get; set; }
    }
}