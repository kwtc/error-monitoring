using Kwtc.ErrorMonitoring.Application.Abstractions.Mapping;

namespace Kwtc.ErrorMonitoring.Application;

public static class MapperExtensions
{
    public static TTarget MapNew<TSource, TTarget>(this IMapper<TSource, TTarget> mapper, TSource source) where TTarget : new()
    {
        var target = new TTarget();
        mapper.Map(source, target);
        return target;
    }

    public static TTarget[] MapCollection<TSource, TTarget>(this IMapper<TSource, TTarget> mapper, IEnumerable<TSource> sources) where TTarget : new()
    {
        return sources.Select(mapper.MapNew).ToArray();
    }
}
