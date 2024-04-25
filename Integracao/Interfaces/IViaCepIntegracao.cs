using System.Globalization;
using WebAPIMaster.Integracao.Response;

namespace WebAPIMaster.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
