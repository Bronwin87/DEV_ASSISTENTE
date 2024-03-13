using ASSISTENTE.Common.Results;

namespace ASSISTENTE.Infrastructure.MarkDownParser.Errors;

internal static class MarkDownParserErrors
{
    public static readonly Error UnsupportedBlock = new(
        "MarkDownParser.UnsupportedBlock", "Block is not supported");
    
    public static readonly Error EmptyContent = new(
        "MarkDownParser.EmptyContent", "File content is empty");
}