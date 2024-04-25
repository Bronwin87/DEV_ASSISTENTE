using ASSISTENTE.Application.Knowledge.Commands.FindResources;
using ASSISTENTE.Contract.Internal.Messages.Knowledge;
using ASSISTENTE.Worker.Sync.Common.Bases;
using MediatR;

namespace ASSISTENTE.Worker.Sync.Consumers;

public sealed class OnFindResourcesMessageConsumer(ISender mediator)
    : ResultConsumerBase<FindResourcesMessage, FindResourcesCommand>(mediator)
{
    protected override FindResourcesCommand MediatRequest(FindResourcesMessage message)
        => FindResourcesCommand.Create(message.QuestionId);
}