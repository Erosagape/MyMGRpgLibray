﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace MGRpgLibrary
{
    public enum ChangeType { Change, Pop, Push }
    public class GameStateManager : GameComponent
    {
        public event EventHandler OnStateChange;
        Stack<GameState> gameStates=new Stack<GameState>();
        const int startDrawOrder = 5000;
        const int drawOrderInc = 100;
        int drawOrder;
        public GameState CurrentState
        {
            get { return gameStates.Peek(); }
        }
        public GameStateManager(Game game) : base(game) 
        {
            drawOrder = startDrawOrder;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public void PopState()
        {
            if (gameStates.Count > 0)
            {
                RemoveState();
                drawOrder = drawOrderInc;
                if (OnStateChange != null)
                    OnStateChange(this, null);
            }
        }
        private void RemoveState()
        {
            GameState State = gameStates.Peek();
            OnStateChange -= State.StateChange;
            Game.Components.Remove(State);
            gameStates.Pop();
        }
        public void PushState(GameState newState)
        {
            drawOrder += drawOrderInc;
            newState.DrawOrder = drawOrder;
            AddState(newState);
            if (OnStateChange != null)
                OnStateChange(this, null);

        }
        private void AddState(GameState state)
        {
            gameStates.Push(state);
            Game.Components.Add(state);
            OnStateChange += state.StateChange;
        }
        public void ChangeState(GameState newState)
        {
            while (gameStates.Count > 0)
                RemoveState();
            newState.DrawOrder = startDrawOrder;
            drawOrder = startDrawOrder;
            AddState(newState);
            if (OnStateChange != null)
                OnStateChange(this, null);
        }
    }
}