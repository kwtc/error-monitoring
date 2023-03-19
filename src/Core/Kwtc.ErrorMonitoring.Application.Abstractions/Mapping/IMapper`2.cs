namespace Kwtc.ErrorMonitoring.Application.Abstractions.Mapping;

public interface IMapper<in TSource, in TTarget>
{
    void Map(TSource source, TTarget target);
}
