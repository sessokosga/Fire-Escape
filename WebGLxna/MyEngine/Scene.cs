
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using WebGLxna;
namespace MyEngine
{
    public abstract class Scene
    {
        protected MainGame mainGame;
        protected Rectangle Screen;
        public Scene(MainGame pGame)
        {
            mainGame = pGame;
            Screen = mainGame.Window.ClientBounds;
        }
        public virtual void Load() { }
        public virtual void Update(GameTime gameTime)
        {
            // Debug.WriteLine("Updating Scene...");            

        }
        public virtual void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene...");
            

        }
        public virtual void Unload() { }
    }
}