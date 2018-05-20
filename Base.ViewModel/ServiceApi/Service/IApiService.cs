using Fusillade;

namespace Base.ViewModel.ServiceApi.Service
{
    public interface IApiService<T>
    {
        T GetApi(Priority priority);
    }
}
