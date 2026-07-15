using Hypex.Application.Common;
using Hypex.Domain.Common;

namespace Hypex.Api.Infrastructure;

/// <summary>
/// Resolves the request language from the "lang" query string or the
/// Accept-Language header, defaulting to Russian. Only ru/uz/en are honored.
/// </summary>
public class HttpLanguageContext(IHttpContextAccessor accessor) : ILanguageContext
{
    public string Current
    {
        get
        {
            var http = accessor.HttpContext;
            if (http is null)
                return Languages.Ru;

            // 1) explicit ?lang= override
            var q = http.Request.Query["lang"].ToString();
            if (Languages.IsSupported(q))
                return q.ToLowerInvariant();

            // 2) Accept-Language header (first supported tag wins)
            foreach (var raw in http.Request.Headers.AcceptLanguage)
            {
                if (string.IsNullOrEmpty(raw)) continue;
                foreach (var part in raw.Split(','))
                {
                    var tag = part.Split(';')[0].Trim().ToLowerInvariant();
                    var primary = tag.Split('-')[0];
                    if (Languages.IsSupported(primary))
                        return primary;
                }
            }

            return Languages.Ru;
        }
    }
}
