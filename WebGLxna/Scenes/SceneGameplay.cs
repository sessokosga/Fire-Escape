using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyEngine;
using Sprache;

namespace WebGLxna
{
    public class SceneGameplay : Scene
    {
        public enum RoomType
        {
            Kitchen,
            Couloir1,
            Couloir2,
            Principal,
            Chamber
        }

        private KeyboardState oldKBState;
        private string input;
        private const int progressBarWidth = 10;
        private float smokeGauge = 0;
        private bool isKeyAvailable;
        private const float maxTime = 5 * 60 * 1000;
        private float elapsedTime = 0;
        private Dictionary<string,string> Inventory;
        private TextInput textInput;
        private string parsedInput;
        private List<Prompt> ListPrompts;
        private RoomType currentRoom;
        private Dictionary<string,string> ListObjects;
        public SceneGameplay(MainGame pGame) : base(pGame)
        {
            currentRoom = RoomType.Chamber;
            textInput = new TextInput();
            input = textInput.input;
            ListPrompts = new List<Prompt>();
            ListObjects = new Dictionary<string,string>();            
            Inventory = new Dictionary<string,string>();
            isKeyAvailable=false;
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
            if (elapsedTime < maxTime)
            {
                elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
                smokeGauge = elapsedTime * (float)progressBarWidth / maxTime;
            }

            ListObjects.Clear();
            switch(currentRoom){
                case RoomType.Kitchen:
                    if (!Inventory.ContainsKey("hammer"))
                        ListObjects.Add("hammer","A hammer");
                break;
                case RoomType.Chamber:
                    if (!isKeyAvailable)
                        ListObjects.Add("box", "A wood box");
                    if(isKeyAvailable && !Inventory.ContainsKey("key"))
                        ListObjects.Add("key", "A key");
                break;
            }

            //  Keyboard
            KeyboardState newKBState = Keyboard.GetState();
            textInput.Update(gameTime, newKBState, oldKBState);
            input = textInput.input.Trim();
            if (newKBState.IsKeyDown(Keys.Enter) && !oldKBState.IsKeyDown(Keys.Enter))
            {
                if (input != "")
                {
                    if (input.Length > 0)
                        parsedInput = TextParser.Identifier.Parse(input);
                }
                var parts = input.Split(" ");
                if (parts.Length > 1 && (parsedInput == "desc" || parsedInput == "describe" || parsedInput == "take" || parsedInput == "use"))
                {
                    parsedInput += " " + parts[1];
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

        private string ProcessInput(string parsedInput)
        {
            var result = "hello kitty";
            List<string> wrongDir;
            // Move around
            switch (currentRoom)
            {
                case RoomType.Kitchen:
                    wrongDir = new List<string> { "w", "s", "n", "west", "south", "north" };
                    if (parsedInput == "e" || parsedInput == "east")
                    {
                        currentRoom = RoomType.Couloir1;
                        result = "You entered in Couloir #1";
                    }
                    else if (wrongDir.Contains(parsedInput))
                    {
                        result = "You can't go that direction";
                    }
                    else
                    {
                        result = "I don't understand what you just said.";
                    }

                    break;
                case RoomType.Chamber:
                    wrongDir = new List<string> { "s", "n", "e", "south", "north", "east" };
                    if (parsedInput == "w" || parsedInput == "west")
                    {
                        currentRoom = RoomType.Couloir2;
                        result = "You entered in Couloir #2";
                    }
                    else if (wrongDir.Contains(parsedInput))
                    {
                        result = "You can't go that direction";
                    }
                    else
                    {
                        result = "I don't understand what you just said.";
                    }
                    break;
                case RoomType.Couloir1:
                    wrongDir = new List<string> { "s", "n", "south", "north" };
                    if (parsedInput == "e" || parsedInput == "east")
                    {
                        currentRoom = RoomType.Principal;
                        result = "You entered in the principal room";
                    }
                    else if (parsedInput == "w" || parsedInput == "west")
                    {
                        currentRoom = RoomType.Kitchen;
                        result = "You are in the kitchen";
                    }
                    else if (wrongDir.Contains(parsedInput))
                    {
                        result = "You can't go that direction";
                    }
                    else
                    {
                        result = "I don't understand what you just said.";
                    }
                    break;
                case RoomType.Couloir2:
                    wrongDir = new List<string> { "w", "s", "west", "south" };
                    if (parsedInput == "e" || parsedInput == "east")
                    {
                        currentRoom = RoomType.Chamber;
                        result = "You entered in your chamber";
                    }
                    else if (parsedInput == "n" || parsedInput == "north")
                    {
                        currentRoom = RoomType.Principal;
                        result = "You are in the principal room";
                    }
                    else if (wrongDir.Contains(parsedInput))
                    {
                        result = "You can't go that direction";
                    }
                    else
                    {
                        result = "I don't understand what you just said.";
                    }
                    break;
                case RoomType.Principal:
                    wrongDir = new List<string> { "n", "e", "north", "east" };
                    if (parsedInput == "s" || parsedInput == "south")
                    {
                        currentRoom = RoomType.Couloir2;
                        result = "You are in Couloir #2";
                    }
                    else if (parsedInput == "w" || parsedInput == "west")
                    {
                        currentRoom = RoomType.Couloir1;
                        result = "You are in Couloir #1";
                    }
                    else if (wrongDir.Contains(parsedInput))
                    {
                        result = "You can't go that direction";
                    }
                    else
                    {
                        result = "I don't understand what you just said.";
                    }
                    break;

            }
            var parts = parsedInput.Split(" ");
            // Describe objects
            if (parts[0] == "describe" || parts[0] == "desc")
            {
                if (parts.Length > 1)
                {
                    switch (parts[1])
                    {
                        case "hammer":
                            if (ListObjects.ContainsKey(parts[1] )|| Inventory.ContainsKey(parts[1]) )
                                result = "The hammer is brown, it's hot due to the room temperature";
                            else
                                result = $"This object ({parts[1]}) is neither in your inventory, nor in this room.";
                            break;
                        case "box":
                            if (ListObjects.ContainsKey(parts[1] ))
                                result = "The box is made of wood. It's brown.";
                            else
                                result = $"This object ({parts[1]}) is neither in your inventory, nor in this room.";
                            break;
                        case "key":
                            if (ListObjects.ContainsKey(parts[1] )|| Inventory.ContainsKey(parts[1]) )
                                result = "It is a little, old fashioned key.";
                            else
                                result = $"This object ({parts[1]}) is neither in your inventory, nor in this room.";
                            break;
                        case "door":
                                result = "It's dark, huge, and robust.";
                            break;
                        default:
                            result = $"This object ({parts[1]}) is neither in your inventory, nor in this room.";
                            break;
                    }
                }
                else
                {
                    result = $"Please specify which object you want me to {parts[0]}";
                }
            }

            // Take objects
            if (parts[0] == "take")
            {
                if (parts.Length > 1)
                {
                    switch (parts[1])
                    {
                        case "hammer":
                            if (ListObjects.ContainsKey(parts[1] ) ){
                                Inventory.Add(parts[1],ListObjects[parts[1]]);
                                ListObjects.Remove(parts[1]);
                                result=$"You've taken the {parts[1]}";
                            }
                            else
                                result = $"This object ({parts[1]}) is not in this room.";
                            break;
                        case "box":
                            result = "You can't take the box.";
                            break;
                        case "key":
                            if (ListObjects.ContainsKey(parts[1] ) ){
                                Inventory.Add(parts[1],ListObjects[parts[1]]);
                                ListObjects.Remove(parts[1]);
                                result=$"You've taken the {parts[1]}";
                            }
                            else
                                result = $"This object ({parts[1]}) is not in this room.";
                            break;
                        case "door":
                                result = "You can't take the door.";
                            break;
                        default:
                            result = $"This object ({parts[1]}) is not in this room.";
                            break;
                    }
                }
                else
                {
                    result = $"Please specify which object you want to {parts[0]}";
                }
            }

            return result;
        }


        public override void Draw(GameTime gameTime)
        {
            var x = 20;
            var y = 20;
            var inputY = 0;
            mainGame.spriteBatch.DrawString(mainGame.font, "Smoke propagation", new Vector2(700, 20), Color.WhiteSmoke);
            var gg = "";
            for (var i = 0; i < (int)smokeGauge; i++)
                gg += "=";
            for (var i = gg.Length; i < progressBarWidth; i++)
                gg += "  ";
            mainGame.spriteBatch.DrawString(mainGame.font, $"|{gg}|", new Vector2(720, 45), Color.WhiteSmoke);

            switch (currentRoom)
            {
                case RoomType.Chamber:
                    mainGame.spriteBatch.DrawString(mainGame.font, "Your Chamber", new Vector2(x + 100, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "There is a brown wood box on the ground, it looks surprisingly\n" +
                        "exempt of the fire around. There are smoke coming \nfrom the couloir from west. Nothing can be saved here\n",
                         new Vector2(x, y), Color.White);
                    inputY = y + 100;

                    x += 700;
                    y = 90;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Inventory", new Vector2(x, y), Color.White);
                    foreach(var item in Inventory){
                        y+=25;
                        mainGame.spriteBatch.DrawString(mainGame.font, item.Value, new Vector2(x + 30, y), Color.White);
                    }
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Objects", new Vector2(x, y), Color.White);
                    y += 25;
                    if (ListObjects.ContainsKey("box"))
                        mainGame.spriteBatch.DrawString(mainGame.font, ListObjects["box"], new Vector2(x + 30, y), Color.White);
                    if (ListObjects.ContainsKey("key"))
                        mainGame.spriteBatch.DrawString(mainGame.font, ListObjects["key"], new Vector2(x + 30, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Compass", new Vector2(x, y), Color.White);
                    y += 25;
                    mainGame.spriteBatch.DrawString(mainGame.font, "W", new Vector2(x + 30, y), Color.White);
                    break;
                case RoomType.Kitchen:
                    mainGame.spriteBatch.DrawString(mainGame.font, "Kitchen", new Vector2(x + 100, y), Color.White);
                    y += 60;
                    mainGame.spriteBatch.DrawString(mainGame.font, "There is a hammer layingon the ground.\nThekitchen is filling up with smoke.\n" +
                        "There are some other smoke coming from the couloir from the east.\nYou can go east.",
                         new Vector2(x, y), Color.White);
                    inputY = y + 120;

                    x += 700;
                    y = 90;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Inventory", new Vector2(x, y), Color.White);
                    foreach(var item in Inventory){
                        y+=25;
                        mainGame.spriteBatch.DrawString(mainGame.font, item.Value, new Vector2(x + 30, y), Color.White);
                    }
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Objects", new Vector2(x, y), Color.White);
                    y += 25;
                    if (ListObjects.ContainsKey("hammer"))
                        mainGame.spriteBatch.DrawString(mainGame.font, ListObjects["hammer"], new Vector2(x + 30, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Compass", new Vector2(x, y), Color.White);
                    y += 25;
                    mainGame.spriteBatch.DrawString(mainGame.font, "E", new Vector2(x + 30, y), Color.White);
                    break;
                case RoomType.Couloir1:
                    mainGame.spriteBatch.DrawString(mainGame.font, "Couloir 1", new Vector2(x + 100, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "The couloir is filling up with smoke.\nYou hear stuff burning from the kitchen" +
                        "from west.\nThe walls are darkened by the smoke.\nNothing can be saved here.\nYou can go west or east",
                         new Vector2(x, y), Color.White);
                    inputY = y + 140;

                    x += 700;
                    y = 90;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Inventory", new Vector2(x, y), Color.White);
                    foreach(var item in Inventory){
                        y+=25;
                        mainGame.spriteBatch.DrawString(mainGame.font, item.Value, new Vector2(x + 30, y), Color.White);
                    }
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Objects", new Vector2(x, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Compass", new Vector2(x, y), Color.White);
                    y += 25;
                    mainGame.spriteBatch.DrawString(mainGame.font, "W E", new Vector2(x + 30, y), Color.White);
                    break;
                case RoomType.Couloir2:
                    mainGame.spriteBatch.DrawString(mainGame.font, "Couloir 2", new Vector2(x + 100, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "The couloir is filling with smoke.\nThe room is darkened by the smoke." +
                        "\nYou hear stuff burning in your chamber at east.\nNothing can be saved here.\nYou can go north or east.",
                         new Vector2(x, y), Color.White);
                    inputY = y + 140;

                    x += 700;
                    y = 90;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Inventory", new Vector2(x, y), Color.White);
                    foreach(var item in Inventory){
                        y+=25;
                        mainGame.spriteBatch.DrawString(mainGame.font, item.Value, new Vector2(x + 30, y), Color.White);
                    }
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Objects", new Vector2(x, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Compass", new Vector2(x, y), Color.White);
                    y += 25;
                    mainGame.spriteBatch.DrawString(mainGame.font, "N E", new Vector2(x + 30, y), Color.White);
                    break;
                case RoomType.Principal:
                    mainGame.spriteBatch.DrawString(mainGame.font, "Principal room", new Vector2(x + 100, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "There a door. It's probably the one leading out.\n" +
                        "The room is filling out with smoke.\nYou hear the noise of stuff burning.\n" +
                        "There is a couloir at west and another one at south.",
                         new Vector2(x, y), Color.White);
                    inputY = y + 140;

                    x += 700;
                    y = 90;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Inventory", new Vector2(x, y), Color.White);
                    foreach(var item in Inventory){
                        y+=25;
                        mainGame.spriteBatch.DrawString(mainGame.font, item.Value, new Vector2(x + 30, y), Color.White);
                    }
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Objects", new Vector2(x, y), Color.White);
                    y += 40;
                    mainGame.spriteBatch.DrawString(mainGame.font, "-> Compass", new Vector2(x, y), Color.White);
                    y += 25;
                    mainGame.spriteBatch.DrawString(mainGame.font, "W S", new Vector2(x + 30, y), Color.White);
                    break;
            }
            x = 20;
            y = inputY;
            foreach (var p in ListPrompts)
            {
                mainGame.spriteBatch.DrawString(mainGame.font, $">{p.input}\n{p.result}", new Vector2(x, y), Color.White);
                y += 60;
            }
            // y += 25;
            mainGame.spriteBatch.DrawString(mainGame.font, $">{input}", new Vector2(x, y), Color.White);
            base.Draw(gameTime);
        }
    }
}