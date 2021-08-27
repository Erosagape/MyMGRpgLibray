using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace MGRpgLibrary
{
    public enum MouseButton
    {
        Left,
        Middle,
        Right
    }
    public class InputHandler : GameComponent
    {
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;
        static MouseState mouseState;
        static MouseState lastMouseState;
        static GamePadState[] gamePadStates;
        static GamePadState[] lastGamePadStates;
        public static MouseState MouseState
        {
            get { return mouseState; }
        }
        public static MouseState LastMouseState
        {
            get { return lastMouseState; }
        }
        public static GamePadState[] GamePadStates
        {
            get { return gamePadStates; }
        }
        public static GamePadState[] LastGamePadStates
        {
            get { return lastGamePadStates; }
        }
        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }
        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }
        public InputHandler(Game game) : base(game)
        {
            gamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
            UpdateState();
        }
        public override void Initialize()
        {
            base.Initialize();  
        }
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            lastMouseState = mouseState;
            lastGamePadStates = (GamePadState[])gamePadStates.Clone();
            UpdateState();
            base.Update(gameTime);
        }
        private void UpdateState()
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);

        }
        public static void Flush()
        {
            lastKeyboardState = keyboardState;
            lastMouseState = mouseState;
        }
        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }
        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }
        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }
        public static Point MouseAsPoint
        {
            get { return new Point(mouseState.X,mouseState.Y); }
        }
        public static Vector2 MouseAsVector2
        {
            get { return new Vector2(mouseState.X,mouseState.Y); }
        }
        public static Point LastMouseAsPoint
        {
            get { return new Point(lastMouseState.X, LastMouseState.Y); }
        }
        public static Vector2 LastMouseAsVector2
        {
            get { return new Vector2(LastMouseState.X, LastMouseState.Y); }
        }
        public static bool CheckMousePressed(MouseButton button)
        {
            bool result = false;
            switch (button)
            {
                case MouseButton.Left:
                    result = mouseState.LeftButton == ButtonState.Pressed &&
                        lastMouseState.LeftButton == ButtonState.Released;
                    break;
                case MouseButton.Right:
                    result = mouseState.RightButton == ButtonState.Pressed &&
                        lastMouseState.RightButton == ButtonState.Released;
                    break;
                case MouseButton.Middle:
                    result = mouseState.MiddleButton == ButtonState.Pressed &&
                        lastMouseState.MiddleButton == ButtonState.Released;
                    break;
            }
            return result;
        }
        public static bool CheckMouseReleased(MouseButton button)
        {
            bool result = false;
            switch (button)
            {
                case MouseButton.Left:
                    result = lastMouseState.LeftButton == ButtonState.Pressed &&
                        mouseState.LeftButton == ButtonState.Released;
                    break;
                case MouseButton.Right:
                    result = lastMouseState.RightButton == ButtonState.Pressed &&
                        mouseState.RightButton == ButtonState.Released;
                    break;
                case MouseButton.Middle:
                    result = lastMouseState.MiddleButton == ButtonState.Pressed &&
                        mouseState.MiddleButton == ButtonState.Released;
                    break;
            }
            return result;
        }
        public static bool IsMouseDown(MouseButton button)
        {
            bool result = false;
            switch (button)
            {
                case MouseButton.Left:
                    result = mouseState.LeftButton == ButtonState.Pressed;
                    break;
                case MouseButton.Right:
                    result = mouseState.RightButton == ButtonState.Pressed;
                    break;
                case MouseButton.Middle:
                    result = mouseState.MiddleButton == ButtonState.Pressed;
                    break;
            }
            return result;
        }
        public static bool IsMouseUp(MouseButton button)
        {
            bool result = false;
            switch (button)
            {
                case MouseButton.Left:
                    result = mouseState.LeftButton == ButtonState.Released;
                    break;
                case MouseButton.Right:
                    result = mouseState.RightButton == ButtonState.Released;
                    break;
                case MouseButton.Middle:
                    result = mouseState.MiddleButton == ButtonState.Released;
                    break;
            }
            return result;
        }
        public static bool ButtonReleased(Buttons button,PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonUp(button) && lastGamePadStates[(int)index].IsButtonDown(button);
        }
        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(button) && lastGamePadStates[(int)index].IsButtonUp(button);
        }
        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(button);
        }


    }
}
