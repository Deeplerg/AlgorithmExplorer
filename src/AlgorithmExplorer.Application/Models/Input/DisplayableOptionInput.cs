using AlgorithmExplorer.Infrastructure.Configuration;

namespace AlgorithmExplorer.Application.Models.Input;

public record class DisplayableOptionInput(
    DisplayableCoordinatorOption Option, 
    string Input);