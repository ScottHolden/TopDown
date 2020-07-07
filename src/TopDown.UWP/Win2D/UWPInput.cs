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

        public KeyboardKey GetKeyboardState() =>
            MapKeyState(VirtualKey.W, KeyboardKey.W) |
            MapKeyState(VirtualKey.A, KeyboardKey.A) |
            MapKeyState(VirtualKey.S, KeyboardKey.S) |
            MapKeyState(VirtualKey.D, KeyboardKey.D) |
            MapKeyState(VirtualKey.Space, KeyboardKey.Space);

        private KeyboardKey MapKeyState(VirtualKey key, KeyboardKey resultKey) =>
            _window.GetKeyState(key).HasFlag(CoreVirtualKeyStates.Down) ?
                resultKey : 0;

        public Vector2 GetMousePosition() => 
            new Vector2((float)(_window.PointerPosition.X - _window.Bounds.X),
                        (float)(_window.PointerPosition.Y - _window.Bounds.Y));

    }
}
