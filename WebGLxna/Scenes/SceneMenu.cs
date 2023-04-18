using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using MyEngine;
namespace WebGLxna
{
    public class SceneMenu : Scene
    {
        private string input;
        public SceneMenu(MainGame pGame) : base(pGame)
        {
            input="";
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
            var x=300;
            var y=30;
            // Debug.WriteLine("Drawing Scene Menu...");
            mainGame.spriteBatch.DrawString(mainGame.font, "Fire Escape", new Vector2(x, y), Color.White);
            
            x=100;
            y+=50;
            mainGame.spriteBatch.DrawString(mainGame.font, "A text based adventure game made for the Gamedev.js game jam. \n"+
            "You can Start the game or open the Credits", new Vector2(x, y), Color.White);

            y+=100;
            mainGame.spriteBatch.DrawString(mainGame.font,$">{input}",new Vector2(x,y),Color.White);
            base.Draw(gameTime);
        }
    }
}