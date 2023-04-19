using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyEngine;

public class TextInput{
    public string  input { get; set; }
    private float deleteSpeed = .08f;
    private float timerDelete = 0;

    public TextInput(){
        input="";
    }

    public void Update(GameTime gameTime,KeyboardState newKBState,KeyboardState oldKBState){
        if (newKBState.IsKeyDown(Keys.A) && !oldKBState.IsKeyDown(Keys.A))
            input += Keys.A.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.B) && !oldKBState.IsKeyDown(Keys.B))
            input += Keys.B.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.C) && !oldKBState.IsKeyDown(Keys.C))
            input += Keys.C.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.D) && !oldKBState.IsKeyDown(Keys.D))
            input += Keys.D.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.E) && !oldKBState.IsKeyDown(Keys.E))
            input += Keys.E.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.F) && !oldKBState.IsKeyDown(Keys.F))
            input += Keys.F.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.G) && !oldKBState.IsKeyDown(Keys.G))
            input += Keys.G.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.H) && !oldKBState.IsKeyDown(Keys.H))
            input += Keys.H.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.I) && !oldKBState.IsKeyDown(Keys.I))
            input += Keys.I.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.J) && !oldKBState.IsKeyDown(Keys.J))
            input += Keys.J.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.K) && !oldKBState.IsKeyDown(Keys.K))
            input += Keys.K.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.L) && !oldKBState.IsKeyDown(Keys.L))
            input += Keys.L.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.M) && !oldKBState.IsKeyDown(Keys.M))
            input += Keys.M.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.N) && !oldKBState.IsKeyDown(Keys.N))
            input += Keys.N.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.O) && !oldKBState.IsKeyDown(Keys.O))
            input += Keys.O.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.P) && !oldKBState.IsKeyDown(Keys.P))
            input += Keys.P.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.Q) && !oldKBState.IsKeyDown(Keys.Q))
            input += Keys.Q.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.R) && !oldKBState.IsKeyDown(Keys.R))
            input += Keys.R.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.S) && !oldKBState.IsKeyDown(Keys.S))
            input += Keys.S.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.T) && !oldKBState.IsKeyDown(Keys.T))
            input += Keys.T.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.U) && !oldKBState.IsKeyDown(Keys.U))
            input += Keys.U.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.V) && !oldKBState.IsKeyDown(Keys.V))
            input += Keys.V.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.W) && !oldKBState.IsKeyDown(Keys.W))
            input += Keys.W.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.X) && !oldKBState.IsKeyDown(Keys.X))
            input += Keys.X.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.Y) && !oldKBState.IsKeyDown(Keys.Y))
            input += Keys.Y.ToString().ToLower();
        if (newKBState.IsKeyDown(Keys.Z) && !oldKBState.IsKeyDown(Keys.Z))
            input += Keys.Z.ToString().ToLower();
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
    }
}