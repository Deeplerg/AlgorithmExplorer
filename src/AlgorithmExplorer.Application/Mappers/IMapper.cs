namespace AlgorithmExplorer.Application.Mappers;

public interface IMapper<TFrom, TTo>
{
    TTo Map(TFrom value);
}