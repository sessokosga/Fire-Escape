using System.Diagnostics;
using Microsoft.Xna.Framework;
using MyEngine;
namespace WebGLxna
{
    public class SceneGameover : Scene
    {
        private bool victory { get; set; }
        public SceneGameover(MainGame pGame,bool pVictory) : base(pGame) { 
            victory = pVictory;
        }


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
            if (victory)
                mainGame.spriteBatch.DrawString(mainGame.font, "Game Won !\n\n\nYou escaped the house.\n\n\nThanks for playing", new Vector2(150, 50), Color.White);
            else
                mainGame.spriteBatch.DrawString(mainGame.font, "You died", new Vector2(150, 50), Color.White);
            base.Draw(gameTime);
        }
    }
}