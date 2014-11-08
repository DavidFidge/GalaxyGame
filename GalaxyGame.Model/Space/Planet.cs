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

        public Planet()
        {
            SystemPosition.OrbitTranslation = new Vector3();
            Colour1 = new Color();
            Colour2 = new Color();
            PolarColour = new Color();
            FractalSeed = 0;
        }
    }
}
