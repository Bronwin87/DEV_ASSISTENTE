using ASSISTENTE.Common;

namespace ASSISTENTE.Infrastructure.CodeParser.Errors;

public static class CodeParserErrors
{
    public static readonly Error FailedToParseCodeContent = new(
        "CodeParser.FailedToParseCodeContent", "Failed to parse code content");
    
    public static readonly Error EmptyContent = new(
        "CodeParser.EmptyContent", "File content is empty");
}