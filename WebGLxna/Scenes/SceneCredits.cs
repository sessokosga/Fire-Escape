using System.Diagnostics;
using Microsoft.Xna.Framework;
using MyEngine;
namespace WebGLxna
{
    public class SceneCredits : Scene
    {
        public SceneCredits(MainGame pGame) : base(pGame) { }


        public override void Load()
        {
            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            // Debug.WriteLine("Updating Scene Credits...");
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene Credits...");
            var x=300;
            var y=50;            
            mainGame.spriteBatch.DrawString(mainGame.font, "Credits", new Vector2(x,y), Color.White);
            x=100;
            y+=100;
            mainGame.spriteBatch.DrawString(mainGame.font, "Game dev : Sesso Kosga\nMusics : Benni", new Vector2(x,y), Color.White);
            base.Draw(gameTime);
        }
    }
}