using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MGRpgLibrary.Controls
{
    public class LeftRightSelector : Control
    {
        public event EventHandler SelectionChanged;
        List<string> items = new List<string>();
        public List<string> Items
        {
            get { return items; }
        }
        Texture2D leftTexture;
        Texture2D rightTexture;
        Texture2D stopTexture;
        Color selectedColor = Color.Red;
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }
        int maxItemWidth;
        int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = (int)MathHelper.Clamp(value,0f, items.Count); }
        }
        public string SelectedItem
        {
            get { return Items[selectedIndex]; }
        }           
        public LeftRightSelector(Texture2D leftArrow,Texture2D rightArrow,Texture2D stop)
        {
            leftTexture = leftArrow;
            rightTexture = rightArrow;
            stopTexture = stop;
            TabStop = true;
            Color = Color.White;
        }
        public void SetItems(string[] items,int maxWidth)
        {
            this.items.Clear();
            foreach(string s in items)
            {
                this.items.Add(s);
            }
            maxItemWidth = maxWidth;
        }
        protected void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, null);
            }
        }
        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawTo = position;
            if (selectedIndex != 0)
                spriteBatch.Draw(leftTexture, drawTo, Color.White);
            else
                spriteBatch.Draw(stopTexture, drawTo, Color.White);
            drawTo.X += leftTexture.Width + 5f;
            float itemWidth = spriteFont.MeasureString(items[selectedIndex]).X;
            float offset = (maxItemWidth - itemWidth) / 2;
            drawTo.X += offset;
            if (hasFocus)
                spriteBatch.DrawString(spriteFont, items[selectedIndex], drawTo, selectedColor);
            else
                spriteBatch.DrawString(spriteFont, items[selectedIndex], drawTo, Color);
            drawTo.X += -1 * offset + maxItemWidth + 5f;
            if (selectedIndex != items.Count - 1)
                spriteBatch.Draw(rightTexture, drawTo, Color.White);
            else
                spriteBatch.Draw(stopTexture, drawTo, Color.White);

        }
        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (items.Count == 0)
                return;
            if(InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft,playerIndex)||
                InputHandler.ButtonReleased(Buttons.DPadLeft,playerIndex)||
                InputHandler.KeyReleased(Keys.Left)
                )
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = 0;
                OnSelectionChanged();
            }

            if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.KeyReleased(Keys.Right)
                )
            {
                selectedIndex++;
                if (selectedIndex >= items.Count)
                    selectedIndex = items.Count-1;
                OnSelectionChanged();
            }
        }
    }
}
