using System;
using System.Collections.Generic;
using System.Text;
using MGRpgLibrary.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MGRpgLibrary.SpriteClasses
{
    public class AnimatedSprite
    {
        Dictionary<AnimationKey, Animation> animations;
        AnimationKey currentAnimation;
        public AnimationKey CurrentAnimation
        {
            get { return currentAnimation; }
            set { currentAnimation = value; }
        }
        bool isAnimating;
        public bool IsAnimating
        {
            get { return isAnimating; }
            set { isAnimating = value; }
        }
        Texture2D texture;
        public Vector2 Position;
        Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set 
            {
                velocity = value;
                if (velocity != Vector2.Zero)
                    velocity.Normalize();
            }
        }
        float speed = 200.0f;
        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(speed, 1.0f, 400.0f); }
        }
        public int Width
        {
            get { return animations[currentAnimation].FrameWidth; }
        }
        public int Height
        {
            get { return animations[currentAnimation].FrameHeight; }
        }
        public AnimatedSprite(Texture2D sprite,Dictionary<AnimationKey,Animation> animation)
        {
            texture = sprite;
            animations = new Dictionary<AnimationKey, Animation>();
            foreach(AnimationKey key in animation.Keys)
            {
                animations.Add(key, (Animation)animation[key].Clone());
            }
        }
        public void Update(GameTime gameTime)
        {
            if (isAnimating)
                animations[currentAnimation].Update(gameTime);
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                Position,
                animations[currentAnimation].CurrentFrameRect,
                Color.White
                );
        }
        public void LockToMap() 
        {
            Position.X = MathHelper.Clamp(Position.X, 0, TileMap.WidthInPixels - Width);
            Position.Y = MathHelper.Clamp(Position.Y, 0, TileMap.HeightInPixels - Height);
        }
    }
}
