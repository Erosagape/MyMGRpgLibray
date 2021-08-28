using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MGRpgLibrary.Controls
{
    public class PictureBox : Control
    {
        Texture2D image;
        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        Rectangle sourceRect;
        public Rectangle SourceRectangle
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }
        Rectangle destRect;
        public Rectangle DestinationRectangle
        {
            get { return destRect; }
            set { destRect = value; }
        }
        public PictureBox (Texture2D image,Rectangle destination)
        {
            this.image = image;
            this.destRect = destination;
            sourceRect = new Rectangle(0, 0, image.Width, image.Height);
            Color = Color.White;
        }
        public PictureBox(Texture2D image,Rectangle destination,Rectangle source)
        {
            this.image = image;
            this.destRect = destination;
            sourceRect = source;
            Color = Color.White;
        }
        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, destRect, sourceRect, Color);
        }
        public override void HandleInput(PlayerIndex playerIndex)
        {
            
        }
        public void SetPosition(Vector2 newPosition)
        {
            destRect = new Rectangle(
                (int)newPosition.X,
                (int)newPosition.Y,
                sourceRect.Width,
                sourceRect.Height
                );
        }
    }
}
