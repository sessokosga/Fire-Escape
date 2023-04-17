using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using MyEngine;
namespace WebGLxna
{
    public class SceneMenu : Scene
    {

        public SceneMenu(MainGame pGame) : base(pGame)
        {            
        }

        public void onClickPlay(Button pSender)
        {
            
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
            // Debug.WriteLine("Updating Scene Menu...");
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene Menu...");
            mainGame.spriteBatch.DrawString(mainGame.font, "Fire Escape\n\n\n\nStart\n\nCredits", new Vector2(200, 40), Color.White);
            base.Draw(gameTime);
        }
    }
}