using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyEngine;
using Sprache;

namespace WebGLxna;


public class MyGame : Game
{
    private KeyboardState oldKBState;
    
    GraphicsDeviceManager graphics;
    SpriteFontComponent _spriteFont;
    SpriteBatch _spriteBatch;
    public string input { get; set; }
    public string parsedId { get; set; }
    public string parsedQuote { get; set; }
    SpriteFont _font;
    TextInput textInput;
    public MyGame()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        _spriteFont = new SpriteFontComponent(this);
        oldKBState = Keyboard.GetState();
        Components.Add(_spriteFont);
        textInput = new TextInput();
        return;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        _font = _spriteFont.font;
    }
    protected override void Update(GameTime gameTime)
    {
        KeyboardState newKBState = Keyboard.GetState();
        textInput.Update(gameTime,newKBState,oldKBState);
        if (newKBState.IsKeyDown(Keys.Enter) && !oldKBState.IsKeyDown(Keys.Enter))
        {
            if (input != null)
            {
                input = textInput.input.TrimStart();
                if (input.Length > 0)
                    parsedId = TextParser.Identifier.Parse(input);
            }
            var t = input.Split(" ");
            t[0] = "";
            input = string.Join(" ", t);
        }
        oldKBState = newKBState;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        if (input != null)
            _spriteBatch.DrawString(_font, $"Input : {input}", new Vector2(30, 70), Color.White);
        if (parsedId != null)
            _spriteBatch.DrawString(_font, $"Parsed : {parsedId}", new Vector2(30, 100), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }

}
