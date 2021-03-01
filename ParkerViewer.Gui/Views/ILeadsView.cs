using System;
using System.Collections.Generic;
using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Gui.Views
{
    public interface ILeadsView
    {
        event Action<LeadDto> InsertLead;

        event Action<LeadDto> UpdateLead;

        event Action<int> DeleteLead;

        event Action<ILeadsView> UpdateView;

        List<LeadDto> Leads { get; set; }
    }
}