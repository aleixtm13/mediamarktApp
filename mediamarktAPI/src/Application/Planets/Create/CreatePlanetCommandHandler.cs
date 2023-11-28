using Domain.Planet;
using Domain.Primitives;
using Domain.ValueObjects;
using Domain.DomainErrors;
using ErrorOr;
using MediatR;

namespace Application.Planets.Create;

public sealed class CreatePlanetCommandHandler : IRequestHandler<CreatePlanetCommand, ErrorOr<Unit>>
{
    private readonly IPlanetRepository _planetRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanetCommandHandler(IPlanetRepository planetRepository, IUnitOfWork unitOfWork)
    {
        _planetRepository = planetRepository ?? throw new ArgumentNullException(nameof(planetRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreatePlanetCommand command, CancellationToken cancellationToken)
    {
        if (Orbit.Create(command.OrbitalRadius, command.OrbitalPeriod, command.RotationPeriod) is not Orbit orbit)
        {
            return Errors.Planet.OrbitWithBadFormat;
        }
        var planet = new Planet(
            new PlanetId(Guid.NewGuid()),
            command.Name,
            orbit);
        await _planetRepository.Add(planet);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}