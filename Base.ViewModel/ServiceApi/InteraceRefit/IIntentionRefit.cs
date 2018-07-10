using Base.ViewModel.Model.Intention;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Base.ViewModel.ServiceApi.InteraceRefit
{
    public interface IIntentionRefit
    {
        [Get("/api/Intentions/{prospectId}")]
        Task<HttpResponseMessage> GetByProspect(Guid prospectId, [Header("Authorization")] string token);

        [Get("/api/Intentions/{userEmail}")]
        Task<HttpResponseMessage> GetByUserEmail(string userEmail, [Header("Authorization")] string token);

        [Post("/api/Intentions")]
        Task<HttpResponseMessage> Create([Body]IntentionDTO intention, [Header("Authorization")] string token);

        [Put("/api/Intentions")]
        Task<HttpResponseMessage> Update([Body]IntentionDTO intention, [Header("Authorization")] string token);

        [Delete("/api/Intentions?id={id}")]
        Task<HttpResponseMessage> Delete(Guid id, [Header("Authorization")] string token);
    }
}
