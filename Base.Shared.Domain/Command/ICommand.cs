using MediatR;

namespace Base.Shared.Domain.Command
{
    public interface ICommand : INotification
    {
        void FillEntities();
    }
}
