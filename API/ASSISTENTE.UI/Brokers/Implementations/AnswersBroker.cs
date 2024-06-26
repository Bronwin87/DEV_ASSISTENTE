using ASSISTENTE.Contract.Requests.Internal.Questions.Queries.GetAnswer;
using ASSISTENTE.Language.Identifiers;
using ASSISTENTE.UI.Common.Models;

namespace ASSISTENTE.UI.Brokers.Implementations;

public interface IAnswersBroker
{
    Task<HttpResult<GetAnswerResponse>> GetAnswerAsync(GetAnswerRequest request);
}

public sealed class AnswersBroker(IHttpClientFactory httpFactory, ILogger<AnswersBroker> logger) 
    : BrokerBase(httpFactory, logger, "api/answers"), IAnswersBroker
{
    public async Task<HttpResult<GetAnswerResponse>> GetAnswerAsync(GetAnswerRequest request)
    {
        return await GetDetailsAsync<GetAnswerResponse, QuestionId>(request.QuestionId);
    }
}