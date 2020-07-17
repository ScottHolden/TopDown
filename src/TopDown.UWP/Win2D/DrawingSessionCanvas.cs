using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using System.Numerics;
using TopDown.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Documents;

namespace TopDown.UWP
{
    public class DrawingSessionCanvas : ICanvas
    {
        private readonly CanvasDrawingSession _ds;
        public DrawingSessionCanvas(CanvasDrawingSession ds)
        {
            _ds = ds;
        }

        public void DrawCircle(Vector2 pos, float scale, GameColor color)
        {
            _ds.DrawCircle(pos, scale, GetWin2DColor(color), scale * 2.0f / 3.0f);
        }

        public void DrawLine(Vector2 start, Vector2 end, GameColor color)
        {
            _ds.DrawLine(start, end, GetWin2DColor(color), 4);
        }

        private static Color GetWin2DColor(GameColor color)
        {
            switch (color)
            {
                case GameColor.LightBlue:
                    return Colors.LightBlue;
                case GameColor.Yellow:
                    return Colors.Yellow;
                case GameColor.Red:
                    return Colors.Red;
                case GameColor.Blue:
                    return Colors.Blue;
                case GameColor.Green:
                    return Colors.Green;
                default:
                    return Colors.White;
            }
        }

        public void DrawRect(Vector2 pos, Vector2 size, GameColor color)
        {
            _ds.DrawRoundedRectangle(VectToRect(pos, size), 6, 6, GetWin2DColor(color), 6);
        }

        private static Rect VectToRect(Vector2 pos, Vector2 size) =>
            new Rect(pos.X, pos.Y, size.X, size.Y);

        public void DrawText(Vector2 pos, string text, float size, GameColor color)
        {
            _ds.DrawText(text, pos, GetWin2DColor(color), new CanvasTextFormat
            {
                FontSize = size
            });
        }
    }
}
