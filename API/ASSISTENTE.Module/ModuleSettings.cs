using ASSISTENTE.Common.Settings;

namespace ASSISTENTE.Module;

public sealed class ModuleSettings
{
    public required RabbitSection Rabbit { get; init; }
}