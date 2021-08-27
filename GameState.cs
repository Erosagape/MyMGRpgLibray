using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace MGRpgLibrary
{
    public abstract partial class GameState : DrawableGameComponent
    {
        List<GameComponent> childComponents;
        public List<GameComponent> Components
        {
            get { return childComponents; }
        }
        GameState tag;
        public GameState Tag
        {
            get { return tag; }
        }
        protected GameStateManager StateManager;
        public GameState(Game game,GameStateManager manager) : base(game)
        {
            StateManager = manager;
            childComponents = new List<GameComponent>();
            tag = this;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            foreach(GameComponent component in childComponents)
            {
                if (component.Enabled)
                    component.Update(gameTime);
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawableGameComponent;
            foreach(GameComponent component in childComponents)
            {
                if(component is DrawableGameComponent)
                {
                    drawableGameComponent = (DrawableGameComponent)component;
                    if (drawableGameComponent.Visible)
                        drawableGameComponent.Draw(gameTime);
                }
            }
            base.Draw(gameTime);
        }
        internal protected virtual void StateChange(Object sender,EventArgs e)
        {
            if (StateManager.CurrentState == tag)
            {
                Show();
            } else
            {
                Hide();
            }
        }
        protected virtual void Show()
        {
            Visible = true;
            Enabled = true;
            foreach(GameComponent component in childComponents)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = true;
            }
        }
        protected virtual void Hide()
        {
            Visible = false;
            Enabled = false;
            foreach(GameComponent component in childComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = false;
            }
        }
    }
}
