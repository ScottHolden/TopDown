using System;

namespace TopDown.Core
{
    [Flags]
    public enum InputButton
    {
        W = 1,
        A = 2,
        S = 4,
        D = 8,
        Space = 16,
        LeftMouse = 32,
        RightMouse = 64
    }
}
