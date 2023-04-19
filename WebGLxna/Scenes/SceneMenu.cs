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
        public SceneMenu(MainGame pGame) : base(pGame)
        {
            textInput = new TextInput();
            input = textInput.input;
            ListPrompts = new List<Prompt>();
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
            base.Update(gameTime);
        }

        private string ProcessInput(string parsedId)
        {
            var result = "";
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
            mainGame.spriteBatch.DrawString(mainGame.font, "A text based adventure game made for the Gamedev.js game jam. \n" +
            "You can Start the game or access Credits", new Vector2(x, y), Color.White);

            y += 100;
            foreach (var p in ListPrompts)
            {
                mainGame.spriteBatch.DrawString(mainGame.font, $">{p.input}\n{p.result}", new Vector2(x, y), Color.White);
                y += 60;
            }
            y += 15;

            mainGame.spriteBatch.DrawString(mainGame.font, $">{input}", new Vector2(x, y), Color.White);
            base.Draw(gameTime);
        }
    }
}