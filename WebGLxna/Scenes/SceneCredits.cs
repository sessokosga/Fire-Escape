using System.Diagnostics;
using Microsoft.Xna.Framework;
using MyEngine;
namespace WebGLxna
{
    public class SceneCredits : Scene
    {
        private bool isWriting;
        private float textTimer;
        private int writedCharacter;
        private string text;
        private const float maxTextSpeed = .06f;
        public SceneCredits(MainGame pGame) : base(pGame) { 
            isWriting = true;
            textTimer = 0;
            writedCharacter = 0;
            text = "Game dev : Sesso Kosga\n\n         Musics : Benni";
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
            if (isWriting)
            {
                textTimer += gameTime.ElapsedGameTime.Milliseconds / (float)1000;
                if (textTimer >= maxTextSpeed)
                {
                    textTimer = 0;
                    writedCharacter++;
                }
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene Credits...");
            var x=300;
            var y=50;            
            mainGame.spriteBatch.DrawString(mainGame.font, "Credits", new Vector2(x,y), Color.White);
            x=230;
            y+=80;
            if (isWriting)
            {
                mainGame.spriteBatch.DrawString(mainGame.font, text.Substring(0,writedCharacter), new Vector2(x,y), Color.White);
                if (writedCharacter == text.Length)
                    isWriting=false;
            }else{
            mainGame.spriteBatch.DrawString(mainGame.font, text, new Vector2(x,y), Color.White);
            }
            base.Draw(gameTime);
        }
    }
}