using System.Diagnostics;
using Microsoft.Xna.Framework;
using MyEngine;
namespace WebGLxna
{
    public class SceneGameover : Scene
    {
        private bool isWriting;
        private float textTimer;
        private int writedCharacter;
        private const float maxTextSpeed = .06f;
        private string text;
        public SceneGameover(MainGame pGame, bool victory, string message) : base(pGame)
        {
            isWriting = true;
            textTimer = 0;
            writedCharacter = 0;
            if (victory)
            {
                text = $"{AddSpace(25)}Game Won !" +
                        $"\n\n\n\n{message}" +
                        $"\n\n\n\n{AddSpace(20)}Thanks for playing";
            }
            else
            {
                text = $"{AddSpace(25)}You died !" +
                    $"\n\n\n\n{message}" +
                    $"\n\n\n\n{AddSpace(20)}Thanks for playing";
            }
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

        private string AddSpace(int n)
        {
            var result = "";
            for (var i = 0; i < n; i++)
                result += " ";
            return result;
        }
        public override void Draw(GameTime gameTime)
        {
            if (isWriting)
            {
                mainGame.spriteBatch.DrawString(mainGame.font, text.Substring(0,writedCharacter), new Vector2(150, 30), Color.White);
                if (writedCharacter == text.Length)
                    isWriting=false;
            }
            else
                mainGame.spriteBatch.DrawString(mainGame.font, text, new Vector2(150, 30), Color.White);
            base.Draw(gameTime);
        }
    }
}