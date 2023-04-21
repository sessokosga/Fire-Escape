using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace WebGLxna;
using MyEngine;
public class MainGame : Game
{
    GraphicsDeviceManager graphics;
    public GameState gameState;
    public SpriteFont font;
    public SpriteBatch spriteBatch;
    private SpriteFontComponent _spriteFont;

    public MainGame()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        _spriteFont = new SpriteFontComponent(this);
        IsMouseVisible = true;
        gameState = new GameState(this);
        Components.Add(_spriteFont);
    }

    protected override void Initialize()
    {
        IsMouseVisible = true;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        font = _spriteFont.font;
        spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        gameState.changeScene(GameState.SceneType.Gameplay);
    }

    protected override void Update(GameTime gameTime)
    {
        if (gameState.currentScene != null)
            gameState.currentScene.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin();
        if (gameState.currentScene != null)
            gameState.currentScene.Draw(gameTime);
        spriteBatch.End();
        base.Draw(gameTime);
    }

}