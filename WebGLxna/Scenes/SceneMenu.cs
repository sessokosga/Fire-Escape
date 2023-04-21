using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyEngine;
using Sprache;

namespace WebGLxna
{
    public class SceneMenu : Scene
    {
        private string input;
        private KeyboardState oldKBState;
        private TextInput textInput;
        private string parsedInput;
        private List<Prompt> ListPrompts;
        private bool isWriting;
        private float textTimer;
        private int writedCharacter;
        private string text;
        private bool hasStarted;
        private const float maxTextSpeed = .06f;
        public SceneMenu(MainGame pGame) : base(pGame)
        {
            textInput = new TextInput();
            input = textInput.input;
            ListPrompts = new List<Prompt>();
            isWriting = true;
            textTimer = 0;
            hasStarted = false;
            writedCharacter = 0;
            text = "A text based adventure game made for the Gamedev.js game jam. \nYou can Start the game or access to the Credits";
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
            else
            {

                KeyboardState newKBState = Keyboard.GetState();
                textInput.Update(gameTime, newKBState, oldKBState);
                input = textInput.input.TrimStart();
                if (newKBState.IsKeyDown(Keys.Enter) && !oldKBState.IsKeyDown(Keys.Enter))
                {
                    if (input != "")
                    {
                        if (input.Length > 0)
                            parsedInput = TextParser.Identifier.Parse(input);
                    }
                    var result = ProcessInput(parsedInput);
                    ListPrompts.Add(new Prompt(input, result));
                    if (ListPrompts.Count >= 6)
                    {
                        foreach (var p in ListPrompts)
                        {
                            ListPrompts.Remove(p);
                            break;
                        }
                    }
                    input = "";
                    textInput.input = "";
                }
                oldKBState = newKBState;
            }
            base.Update(gameTime);
        }

        private string ProcessInput(string parsedId)
        {
            var result = "";
            isWriting = true;
            textTimer = 0;
            writedCharacter = 0;
            switch (parsedId)
            {
                case "start":
                    result = "Starting the game";
                    mainGame.gameState.changeScene(GameState.SceneType.Gameplay);
                    break;
                case "launch":
                    result = "Starting the game";
                    mainGame.gameState.changeScene(GameState.SceneType.Gameplay);
                    break;
                case "credits":
                    result = "Opening credits";
                    mainGame.gameState.changeScene(GameState.SceneType.Credits);
                    break;
                case "credit":
                    result = "Opening credits";
                    mainGame.gameState.changeScene(GameState.SceneType.Credits);
                    break;
                default:
                    result = "I don't understand what you just said.";
                    break;
            }
            return result;
        }

        public override void Draw(GameTime gameTime)
        {
            var x = 300;
            var y = 30;
            mainGame.spriteBatch.DrawString(mainGame.font, "Fire Escape", new Vector2(x, y), Color.White);

            x = 100;
            y += 50;
            if (isWriting && hasStarted == false)
            {
                if (writedCharacter >= text.Length)
                {
                    isWriting = false;
                    hasStarted = true;
                }
                mainGame.spriteBatch.DrawString(mainGame.font, text.Substring(0, writedCharacter), new Vector2(x, y), Color.White);
            }
            else
            {
                mainGame.spriteBatch.DrawString(mainGame.font, "A text based adventure game made for the Gamedev.js game jam. \n" +
                "You can Start the game or access to the Credits", new Vector2(x, y), Color.White);
            }

            y += 100;
            var c = 0;
            foreach (var p in ListPrompts)
            {
                c++;
                mainGame.spriteBatch.DrawString(mainGame.font, $">{p.input}", new Vector2(x, y), Color.White);
                y += 25;

                if (c == ListPrompts.Count && isWriting)
                {
                    if (writedCharacter == p.result.Length)
                        isWriting = false;
                    mainGame.spriteBatch.DrawString(mainGame.font, $"{p.result.Substring(0, writedCharacter)}", new Vector2(x, y), Color.White);
                }
                else
                    mainGame.spriteBatch.DrawString(mainGame.font, $"{p.result}", new Vector2(x, y), Color.White);
                y += 30;
            }
            // y += 15;
            if (isWriting == false)
                mainGame.spriteBatch.DrawString(mainGame.font, $">{input}", new Vector2(x, y), Color.White);
            base.Draw(gameTime);
        }
    }
}