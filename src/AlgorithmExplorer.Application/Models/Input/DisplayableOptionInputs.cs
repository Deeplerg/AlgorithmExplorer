using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Models.Input;

public record class DisplayableOptionInputs(
    AlgorithmType OptionName,
    List<DisplayableOptionInput> Inputs);