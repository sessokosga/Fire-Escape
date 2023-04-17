using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyEngine;
namespace WebGLxna
{
    public class SceneGameplay : Scene
    {
        private KeyboardState oldKBState;
        public SceneGameplay(MainGame pGame) : base(pGame)
        {
        }

        public override void Load()
        {
            // Input state
            oldKBState = Keyboard.GetState();

            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
             Debug.WriteLine("Updating Scene Gameplay..."); 
            /**
                Handle inputs
            */
            // Mouse
            // MouseState mouseState = Mouse.GetState();
            // Debug.WriteLine(mouseState.X+", "+mouseState.Y+", "+mouseState.LeftButton);


            //  Keyboard
            // KeyboardState newKBState = Keyboard.GetState();            
            // oldKBState = newKBState;
           
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            mainGame.spriteBatch.DrawString(mainGame.font, "This is the Gameplay", new Vector2(100, 10), Color.White);
            base.Draw(gameTime);
        }
    }
}