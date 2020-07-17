using System.Numerics;
using TopDown.Core;
using Windows.System;
using Windows.UI.Core;

namespace TopDown.UWP
{
    public class UWPInput : IInput
    {
        private readonly CoreWindow _window;

        public UWPInput(CoreWindow window)
        {
            _window = window;
        }

        public InputButton GetInputState() =>
            MapKeyState(VirtualKey.W, InputButton.W) |
            MapKeyState(VirtualKey.A, InputButton.A) |
            MapKeyState(VirtualKey.S, InputButton.S) |
            MapKeyState(VirtualKey.D, InputButton.D) |
            MapKeyState(VirtualKey.Space, InputButton.Space) |
            MapKeyState(VirtualKey.LeftButton, InputButton.LeftMouse) |
            MapKeyState(VirtualKey.RightButton, InputButton.RightMouse);

        private InputButton MapKeyState(VirtualKey key, InputButton resultKey) =>
            _window.GetKeyState(key).HasFlag(CoreVirtualKeyStates.Down) ?
                resultKey : 0;

        public Vector2 GetMousePosition() => 
            new Vector2((float)(_window.PointerPosition.X - _window.Bounds.X),
                        (float)(_window.PointerPosition.Y - _window.Bounds.Y));
    }
}
