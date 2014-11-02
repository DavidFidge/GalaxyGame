namespace GalaxyGame.Service.Interfaces
{
    public interface ISystemSettings
    {
        int MinSolarSystemsInGalaxySector { get; }
        int MaxSolarSystemsInGalaxySector { get; }

        int MinPlanetsInSystem { get; }
        int MaxPlanetsInSystem { get; }
    }
}
