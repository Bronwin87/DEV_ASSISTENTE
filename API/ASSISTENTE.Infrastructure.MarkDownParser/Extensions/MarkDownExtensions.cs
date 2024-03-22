using Markdig.Helpers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace ASSISTENTE.Infrastructure.MarkDownParser.Extensions;

internal static class MarkDownExtensions
{
    public static string GetContent(this LeafBlock leaf)
    {
        if (leaf.Inline == null) return string.Empty;

        var contentsList = leaf.Inline
            .Descendants()
            .OfType<LiteralInline>()
            .Select(x => x.Content)
            .ToList();

        return string.Join(" ", contentsList);
    }

    public static string GetUrls(this LeafBlock leaf)
    {
        if (leaf.Inline == null) return string.Empty;

        var urls = leaf.Inline
            .Descendants()
            .OfType<LinkInline>()
            .Select(x => x.Url)
            .ToList();

        return string.Join(" ", urls);
    }

    public static string GetCodeLine(this LeafBlock leaf)
    {
        var contentsList = leaf.Lines
            .OfType<StringLine>()
            .Select(x => x.ToString())
            .ToList();

        return string.Join("\n", contentsList);
    }

    public static string GetCodeBlock(this LeafBlock leaf)
    {
        var contentsList = leaf.Lines
            .OfType<StringLine>()
            .Select(x => x.ToString())
            .ToList();
        
        var fencedCodeBlock = leaf as FencedCodeBlock;
        var programmingLanguage = string.IsNullOrEmpty(fencedCodeBlock?.Info) ? "unknown" : fencedCodeBlock.Info;
        
        var content = $"""
                       ---------------- Start code block ----------------
                       Programming language: '{programmingLanguage.ToUpper()}'
                       
                       {string.Join("\n", contentsList)};
                       ---------------- End code block ----------------
                       """;

        return content;
    }

    public static string GetListContent(this ListBlock block)
    {
        var listPosition = block
            .OfType<ListItemBlock>()
            .ToList();

        var counter = 1;
        var listContent = new List<string>();

        foreach (var position in listPosition)
        {
            var paragraphs = position.OfType<ParagraphBlock>().ToList();

            foreach (var paragraph in paragraphs)
            {
                var content = paragraph.GetContent();
                var urls = paragraph.GetUrls();

                var line = $"{counter}. {content}";

                if (!string.IsNullOrEmpty(urls))
                    line += $" | Links associated with this point: {urls}";

                listContent.Add(line);
            }

            counter++;
        }

        return string.Join(",\n", listContent);
    }
}