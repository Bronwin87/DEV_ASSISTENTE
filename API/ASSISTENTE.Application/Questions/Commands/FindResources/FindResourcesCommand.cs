﻿using ASSISTENTE.Application.Abstractions.Clients;
using ASSISTENTE.Application.Abstractions.Interfaces;
using ASSISTENTE.Application.Bases;
using ASSISTENTE.Domain.Entities.Questions;
using ASSISTENTE.Domain.Entities.Questions.Interfaces;
using ASSISTENTE.Language.Enums;
using ASSISTENTE.Language.Identifiers;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ASSISTENTE.Application.Questions.Commands.FindResources
{
    public sealed class FindResourcesCommand : IRequest<Result>
    {
        private FindResourcesCommand(QuestionId questionId)
        {
            QuestionId = questionId;
        }

        public QuestionId QuestionId { get; }

        public static FindResourcesCommand Create(QuestionId questionId)
        {
            return new FindResourcesCommand(questionId);
        }
    }

    public class FindResourcesCommandHandler(
        IKnowledgeService knowledgeService,
        IQuestionRepository questionRepository,
        IAssistenteClientInternal clientInternal,
        ILogger<FindResourcesCommandHandler> logger) : QuestionCommandBase<FindResourcesCommand>(logger, clientInternal)
    {
        protected override async Task<Result> HandleAsync(Question question)
            => await knowledgeService.FindResources(question);

        protected override async Task<Maybe<Question>> GetQuestionAsync(FindResourcesCommand request)
            => await questionRepository.GetByIdAsync(request.QuestionId);

        protected override QuestionProgress InitialProgress => QuestionProgress.SearchingForResources;
        protected override QuestionProgress FinalProgress => QuestionProgress.ResourcesFound;
    }
}