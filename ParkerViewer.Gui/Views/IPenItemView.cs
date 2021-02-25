using System;
using System.Collections.Generic;
using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Gui.Views
{
    public interface IPenItemView
    {
        event Action<PenItemDto> InsertPenItem;

        event Action<PenItemDto> UpdatePenItem;

        event Action<int> DeletePenItem;

        event Action<IPenItemView> UpdateView;

        List<PenItemDto> PenItems { get; set; }
    }
}