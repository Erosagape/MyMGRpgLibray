using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MGRpgLibrary.Controls
{
    public class Label : Control
    {
        public Label()
        {
            tabStop = false;
        }
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }
        public override void HandleInput(PlayerIndex playerIndex)
        {
            
        }
    }
}
