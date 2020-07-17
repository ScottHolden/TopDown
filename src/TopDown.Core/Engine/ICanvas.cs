using System.Numerics;

namespace TopDown.Core
{
    public interface ICanvas
    {
        void DrawCircle(Vector2 pos, float scale, GameColor color);
        void DrawLine(Vector2 start, Vector2 end, GameColor color);
        void DrawRect(Vector2 pos, Vector2 size, GameColor color);
        void DrawText(Vector2 pos, string text, float size, GameColor color);
    }
}
