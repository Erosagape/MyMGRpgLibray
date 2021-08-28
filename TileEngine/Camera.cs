using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MGRpgLibrary.TileEngine
{
    public class Camera
    {
        Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            private set { position = value; }
        }
        float speed;
        public float Speed
        {
            get { return speed; }
            set
            {
                speed = (float)MathHelper.Clamp(speed, 1f, 16f);
            }
        }
        float zoom;
        public float Zoom
        {
            get { return zoom;  }
        }
        Rectangle viewportRectangle;
        public Camera(Rectangle viewportRect)
        {
            speed = 4f;
            zoom = 1f;
            viewportRectangle = viewportRect;
        }
        public Camera(Rectangle viewportRect,Vector2 position)
        {
            speed = 4f;
            zoom = 1f;
            viewportRectangle = viewportRect;
            Position = position;
        }
        public void Update(GameTime gameTime)
        {
            Vector2 motion = Vector2.Zero;
            if (InputHandler.KeyDown(Keys.Left))
                position.X -= speed;
            else if (InputHandler.KeyDown(Keys.Right))
                position.X += speed;

            if (InputHandler.KeyDown(Keys.Up))
                position.Y -= speed;
            else if (InputHandler.KeyDown(Keys.Down))
                position.Y += speed;

            if (motion != Vector2.Zero)
                motion.Normalize();
            position += motion * speed;
            LockCamera();
        }
        private void LockCamera()
        {
            position.X = MathHelper.Clamp(position.X, 0, TileMap.WidthInPixels - viewportRectangle.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, TileMap.HeightInPixels - viewportRectangle.Height);
        }
    }
}
