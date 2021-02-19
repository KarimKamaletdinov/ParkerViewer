using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Dtos;

namespace ParkerViewer
{
    public class GetModelsQuery : Query<ModelDto[]>
    {
        public int UserId;
    }
}