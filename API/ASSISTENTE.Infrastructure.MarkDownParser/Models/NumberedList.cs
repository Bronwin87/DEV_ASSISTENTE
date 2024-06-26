using ASSISTENTE.Infrastructure.MarkDownParser.Contracts.Models;

namespace ASSISTENTE.Infrastructure.MarkDownParser.Models;

internal sealed record NumberedList(string Content) : ElementBase(Content)
{
    public override string GetContent() => Content;
}