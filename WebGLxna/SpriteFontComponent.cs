using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace WebGLxna
{
    public class SpriteFontComponent : DrawableGameComponent
    {
        ContentManager _content;
        public SpriteFont font;

        public SpriteFontComponent(Game game) : base(game)
        {
            _content = new ContentManager(game.Services);
            _content.RootDirectory = "Content";

        }


        protected override void LoadContent()
        {           
            font = _content.Load<SpriteFont>("Font");

        }

        public override void Draw(GameTime gameTime)
        {

        }

        protected override void Dispose(bool disposing) 
        {

            _content = null;
            font = null;
        }
    }
}
