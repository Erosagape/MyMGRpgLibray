using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.ItemClasses
{
    public class GameItemManager
    {

        #region Field Region
        readonly Dictionary<string, GameItem> gameItems = new Dictionary<string, GameItem>();
        static SpriteFont spriteFont;
        #endregion
        #region Property Region
        public Dictionary<string,GameItem> GameItems
        {
            get { return gameItems; }
        }
        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
            private set { spriteFont = value; }
        }
        #endregion
        #region Constructor Region
        public GameItemManager(SpriteFont spriteFont)
        {
            SpriteFont = spriteFont;
        }
        #endregion
        #region Method Region
        #endregion
        #region Virtual Method region
        #endregion

    }
}
