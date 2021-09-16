using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGRpgLibrary.Controls
{
    public abstract class Control
    {
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        protected string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        protected Vector2 size;
        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }
        protected Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                position.Y = (int)position.Y;
            }
        }
        protected object value;
        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }
        protected bool hasFocus;
        public virtual bool HasFocus
        {
            get { return hasFocus; }
            set { hasFocus = value; }
        }
        protected bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        protected bool visible;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        protected bool tabStop;
        public bool TabStop
        {
            get { return tabStop; }
            set
            {
                tabStop = value;
            }
        }
        protected SpriteFont spriteFont;
        public SpriteFont SpriteFont
        {
            get { return spriteFont; }
            set { spriteFont = value; }
        }
        protected Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        protected string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
            }
        }
        public EventHandler Selected;
        
        public Control()
        {
            color = Color.White;
            enabled = true;
            visible = true;
            spriteFont = ControlManager.SpriteFont;
        }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);
        public virtual void OnSelected(EventArgs e)
        {
            if (Selected != null)
            {
                Selected(this, e);
            }
        }
    }
}
