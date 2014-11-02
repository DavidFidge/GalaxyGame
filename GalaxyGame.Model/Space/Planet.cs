using GalaxyGame.Model.Unity;

namespace GalaxyGame.Model.Space
{
    public class Planet : SpaceObject
    {
        // Black = colour not used
        public virtual Color Colour1 { get; set; }
        public virtual Color Colour2 { get; set; }
        public virtual Color PolarColour { get; set; }
        public virtual double FractalSeed { get; set; }
    }
}
