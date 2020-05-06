using Otter.Core;
using Otter.Graphics.Text;
using Otter.Utility;
using System;
using System.Linq;

namespace PlatformingExample
{
    class PlatformerScene : Scene
    {
        OgmoProject.OgmoVersion _version;
        Text _versionText;

        public PlatformerScene() : base()
        {
            _version = OgmoProject.OgmoVersion.Version2;
            Load(_version);
        }

        void Load(OgmoProject.OgmoVersion version)
        {
            // Create the Ogmo Editor project.
            OgmoProject ogmoProject;

            _version = version;

            if (_version == OgmoProject.OgmoVersion.Version2)
            {
                ogmoProject = new OgmoProject("OgmoProject.oep");
            }
            else if (_version == OgmoProject.OgmoVersion.Version3)
            {
                ogmoProject = new OgmoProject("Ogmo3Project.ogmo");
            }
            else
            {
                throw new Exception();
            }

            // Register the "Solid" layer with the tag Solid.
            ogmoProject.RegisterTag(CollisionTag.Solid, "Solid");

            // Set the game's color to the Ogmo Project's background color.
            Game.Instance.Color = ogmoProject.BackgroundColor;

            // Load the level.
            if (_version == OgmoProject.OgmoVersion.Version2)
            {
                ogmoProject.LoadLevel("Level.oel", this);
            }
            else if (_version == OgmoProject.OgmoVersion.Version3)
            {
                ogmoProject.LoadLevel("Level.json", this);
            }
            else
            {
                throw new Exception();
            }

            _versionText = new Text(_version == OgmoProject.OgmoVersion.Version2 ? "Version 2 (XML)" : "Version 3 (JSON)", 16);
        }

        public override void Update()
        {
            if (Input.KeyPressed(Key.K))
            {
                if (_version == OgmoProject.OgmoVersion.Version2)
                    return;

                RemoveAll();
                Load(OgmoProject.OgmoVersion.Version2);
            }

            if (Input.KeyPressed(Key.L))
            {
                if (_version == OgmoProject.OgmoVersion.Version3)
                    return;

                RemoveAll();
                Load(OgmoProject.OgmoVersion.Version3);
            }
        }

        public override void Render()
        {
            _versionText.Render(10, 10);

            base.Render();
        }
    }
}
