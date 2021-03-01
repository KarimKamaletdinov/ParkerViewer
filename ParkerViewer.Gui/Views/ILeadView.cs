using System;
using System.Collections.Generic;
using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Gui.Views
{
    public interface ILeadView
    {
        event Action<LeadDto> InsertLead;

        event Action<LeadDto> UpdateLead;

        event Action<int> DeleteLead;

        event Action<ILeadView> UpdateView;

        List<LeadDto> Leads { get; set; }
    }
}