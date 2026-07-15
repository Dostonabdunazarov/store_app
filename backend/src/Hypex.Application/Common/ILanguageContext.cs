namespace Hypex.Application.Common;

/// <summary>Resolves the effective request language (ru/uz/en) with a safe default.</summary>
public interface ILanguageContext
{
    /// <summary>Current normalized language code; defaults to "ru".</summary>
    string Current { get; }
}
