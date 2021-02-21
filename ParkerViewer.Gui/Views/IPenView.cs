using System;
using System.Collections.Generic;
using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer.Gui.Views
{
    public interface IPenView
    {
        event Action<PenDto> InsertPen;

        event Action<PenDto> UpdatePen;

        event Action<int> DeletePen;

        event Action<IPenView> UpdateView;

        List<PenDto> Pens { get; set; }
    }
}