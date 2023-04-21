using System.Diagnostics;
using Microsoft.Xna.Framework;
using MyEngine;
namespace WebGLxna
{
    public class SceneGameover : Scene
    {
        private bool victory;
        private string message;
        public SceneGameover(MainGame pGame,bool pVictory, string pMessage) : base(pGame) { 
            victory = pVictory;
            message = pMessage;
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
            if (victory){
                mainGame.spriteBatch.DrawString(mainGame.font, "Game Won !", new Vector2(270, 30), Color.White);
                mainGame.spriteBatch.DrawString(mainGame.font, $"\n\n\n{message}", new Vector2(150, 50), Color.White);
                mainGame.spriteBatch.DrawString(mainGame.font, "\n\n\n\n\n\n\n\nThanks for playing", new Vector2(245, 50), Color.White);
            }else{
                mainGame.spriteBatch.DrawString(mainGame.font, "You died !", new Vector2(270, 30), Color.White);
                mainGame.spriteBatch.DrawString(mainGame.font, $"\n\n\n{message}", new Vector2(150, 50), Color.White);
                mainGame.spriteBatch.DrawString(mainGame.font, "\n\n\n\n\n\n\nThanks for playing", new Vector2(245, 50), Color.White);
            }
            base.Draw(gameTime);
        }
    }
}