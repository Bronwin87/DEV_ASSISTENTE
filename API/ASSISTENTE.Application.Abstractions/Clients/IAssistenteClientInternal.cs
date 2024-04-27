using ASSISTENTE.Contract.Requests.Internal.Knowledge.Commands.UpdateQuestion;
using CSharpFunctionalExtensions;

namespace ASSISTENTE.Application.Abstractions.Clients;

public interface IAssistenteClientInternal
{
    public Task<Result> UpdateQuestionAsync(UpdateQuestionRequest request);
}