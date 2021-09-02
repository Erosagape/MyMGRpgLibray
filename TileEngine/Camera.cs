using System;
using System.Collections.Generic;
using System.Text;
using MGRpgLibrary.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MGRpgLibrary.TileEngine
{
    public enum CameraMode { Free,Follow }
    public class Camera
    {
        CameraMode mode;
        public CameraMode CameraMode 
        { 
            get { return mode; }
        }
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
            mode = CameraMode.Follow;
        }
        public Camera(Rectangle viewportRect,Vector2 position)
        {
            speed = 4f;
            zoom = 1f;
            viewportRectangle = viewportRect;
            Position = position;
            mode = CameraMode.Follow;
        }
        public void Update(GameTime gameTime)
        {
            if (mode == CameraMode.Follow)
                return;

            Vector2 motion = Vector2.Zero;
            if (InputHandler.KeyDown(Keys.Left) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickLeft,PlayerIndex.One))
                position.X = -speed;
            else if (InputHandler.KeyDown(Keys.Right) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickRight, PlayerIndex.One))
                position.X = speed;

            if (InputHandler.KeyDown(Keys.Up) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickUp, PlayerIndex.One))
                position.Y =-speed;
            else if (InputHandler.KeyDown(Keys.Down) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickDown, PlayerIndex.One))
                position.Y =speed;

            if (motion != Vector2.Zero)
            {
                motion.Normalize();
                position += motion * speed;
                LockCamera();
            }                            
        }
        private void LockCamera()
        {
            position.X = MathHelper.Clamp(position.X, 0, TileMap.WidthInPixels - viewportRectangle.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, TileMap.HeightInPixels - viewportRectangle.Height);
        }
        public void LockToSprite(AnimatedSprite sprite)
        {
            position.X = sprite.Position.X + sprite.Width / 2
                - (viewportRectangle.Width / 2);
            position.Y = sprite.Position.Y + sprite.Height / 2
                - (viewportRectangle.Height / 2);

            LockCamera();
        }
        public void ToggleCameraMode()
        {
            if (mode == CameraMode.Follow)
                mode = CameraMode.Free;
            else if (mode == CameraMode.Free)
                mode = CameraMode.Follow;
        }
    }
}
