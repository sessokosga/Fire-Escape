using System.Diagnostics;
using Microsoft.Xna.Framework;
using MyEngine;
namespace WebGLxna
{
    public class SceneGameover : Scene
    {
        public SceneGameover(MainGame pGame) : base(pGame) { }


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
            // Debug.WriteLine("Updating Scene Gameover...");
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene Gameover...");
            mainGame.spriteBatch.DrawString(mainGame.font, "Game Over", new Vector2(150, 50), Color.White);
            base.Draw(gameTime);
        }
    }
}