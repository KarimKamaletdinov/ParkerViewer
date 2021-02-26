using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Abstractions.Commands.Lead
{
    public class UpdateLead : Command
    {
        public LeadDto Lead { get; set; }
    }
}