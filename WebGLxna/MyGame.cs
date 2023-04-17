using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprache;

namespace WebGLxna;


public class MyGame : Game
{
    private KeyboardState oldKBState;
    private float deleteSpeed = .08f;
    private float timerDelete = 0;
    GraphicsDeviceManager graphics;
    SpriteFontComponent _spriteFont;
    SpriteBatch _spriteBatch;
    public string input { get; set; }
    public string parsedId { get; set; }
    public string parsedQuote { get; set; }
    SpriteFont _font;
    public MyGame()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        _spriteFont = new SpriteFontComponent(this);
        oldKBState = Keyboard.GetState();
        Components.Add(_spriteFont);

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

        if (newKBState.IsKeyDown(Keys.A) && !oldKBState.IsKeyDown(Keys.A))
            input += Keys.A.ToString();
        if (newKBState.IsKeyDown(Keys.B) && !oldKBState.IsKeyDown(Keys.B))
            input += Keys.B.ToString();
        if (newKBState.IsKeyDown(Keys.C) && !oldKBState.IsKeyDown(Keys.C))
            input += Keys.C.ToString();
        if (newKBState.IsKeyDown(Keys.D) && !oldKBState.IsKeyDown(Keys.D))
            input += Keys.D.ToString();
        if (newKBState.IsKeyDown(Keys.E) && !oldKBState.IsKeyDown(Keys.E))
            input += Keys.E.ToString();
        if (newKBState.IsKeyDown(Keys.F) && !oldKBState.IsKeyDown(Keys.F))
            input += Keys.F.ToString();
        if (newKBState.IsKeyDown(Keys.G) && !oldKBState.IsKeyDown(Keys.G))
            input += Keys.G.ToString();
        if (newKBState.IsKeyDown(Keys.H) && !oldKBState.IsKeyDown(Keys.H))
            input += Keys.H.ToString();
        if (newKBState.IsKeyDown(Keys.I) && !oldKBState.IsKeyDown(Keys.I))
            input += Keys.I.ToString();
        if (newKBState.IsKeyDown(Keys.J) && !oldKBState.IsKeyDown(Keys.J))
            input += Keys.J.ToString();
        if (newKBState.IsKeyDown(Keys.K) && !oldKBState.IsKeyDown(Keys.K))
            input += Keys.K.ToString();
        if (newKBState.IsKeyDown(Keys.L) && !oldKBState.IsKeyDown(Keys.L))
            input += Keys.L.ToString();
        if (newKBState.IsKeyDown(Keys.M) && !oldKBState.IsKeyDown(Keys.M))
            input += Keys.M.ToString();
        if (newKBState.IsKeyDown(Keys.N) && !oldKBState.IsKeyDown(Keys.N))
            input += Keys.N.ToString();
        if (newKBState.IsKeyDown(Keys.O) && !oldKBState.IsKeyDown(Keys.O))
            input += Keys.O.ToString();
        if (newKBState.IsKeyDown(Keys.P) && !oldKBState.IsKeyDown(Keys.P))
            input += Keys.P.ToString();
        if (newKBState.IsKeyDown(Keys.Q) && !oldKBState.IsKeyDown(Keys.Q))
            input += Keys.Q.ToString();
        if (newKBState.IsKeyDown(Keys.R) && !oldKBState.IsKeyDown(Keys.R))
            input += Keys.R.ToString();
        if (newKBState.IsKeyDown(Keys.S) && !oldKBState.IsKeyDown(Keys.S))
            input += Keys.S.ToString();
        if (newKBState.IsKeyDown(Keys.T) && !oldKBState.IsKeyDown(Keys.T))
            input += Keys.T.ToString();
        if (newKBState.IsKeyDown(Keys.U) && !oldKBState.IsKeyDown(Keys.U))
            input += Keys.U.ToString();
        if (newKBState.IsKeyDown(Keys.V) && !oldKBState.IsKeyDown(Keys.V))
            input += Keys.V.ToString();
        if (newKBState.IsKeyDown(Keys.W) && !oldKBState.IsKeyDown(Keys.W))
            input += Keys.W.ToString();
        if (newKBState.IsKeyDown(Keys.X) && !oldKBState.IsKeyDown(Keys.X))
            input += Keys.X.ToString();
        if (newKBState.IsKeyDown(Keys.Y) && !oldKBState.IsKeyDown(Keys.Y))
            input += Keys.Y.ToString();
        if (newKBState.IsKeyDown(Keys.Z) && !oldKBState.IsKeyDown(Keys.Z))
            input += Keys.Z.ToString();
        if (newKBState.IsKeyDown(Keys.Space) && !oldKBState.IsKeyDown(Keys.Space))
            input += " ";
        if (newKBState.IsKeyDown(Keys.Back) && input != null && input.Length > 0)
        {
            timerDelete -= gameTime.ElapsedGameTime.Milliseconds / (float)1000;
            if (timerDelete <= 0)
            {
                input = input.Remove(input.Length - 1);
                timerDelete = deleteSpeed;
            }
        }
        if (newKBState.IsKeyUp(Keys.Back))
            timerDelete = 0;
        if (newKBState.IsKeyDown(Keys.Enter) && !oldKBState.IsKeyDown(Keys.Enter))
        {
            if (input != null)
            {
                input = input.TrimStart();
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
