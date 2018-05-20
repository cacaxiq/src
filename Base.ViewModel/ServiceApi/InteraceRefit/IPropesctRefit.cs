using Base.ViewModel.Model.Base;
using Base.ViewModel.Model.Prospect;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InteraceRefit
{
    public interface IPropesctRefit
    {
        [Post("/api/Prospects")]
        Task<HttpResponseMessage> Create([Body]ProspectDTO prospect, [Header("Authorization")] string token);

        [Put("/api/Prospects")]
        Task<HttpResponseMessage> Update([Body]ProspectDTO prospect, [Header("Authorization")] string token);

        [Delete("/api/Prospects?id={id}")]
        Task<HttpResponseMessage> Delete(Guid id, [Header("Authorization")] string token);
    }
}
