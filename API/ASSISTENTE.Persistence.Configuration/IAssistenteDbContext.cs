using ASSISTENTE.Domain.Common.Interfaces;
using ASSISTENTE.Domain.Entities.Answers;
using ASSISTENTE.Domain.Entities.Questions;
using ASSISTENTE.Domain.Entities.Resources;
using Microsoft.EntityFrameworkCore;

namespace ASSISTENTE.Persistence.Configuration;

public interface IAssistenteDbContext
{
    #region ENTITIES

    DbSet<Resource> Resources { get; set; }
    DbSet<Question> Questions { get; set; }
    DbSet<QuestionResource> QuestionResources { get; set; }
    DbSet<QuestionFile> QuestionFiles { get; set; }
    DbSet<Answer> Answers { get; set; }

    #endregion

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;
}