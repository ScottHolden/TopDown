using Microsoft.Graphics.Canvas;
using System.Numerics;
using TopDown.Core;
using Windows.UI;

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
            _ds.DrawCircle(pos, 4 * scale, GetWin2DColor(color), scale * 3);
        }

        private Color GetWin2DColor(GameColor color)
        {
            switch (color)
            {
                case GameColor.LightBlue:
                    return Colors.LightBlue;
                case GameColor.Yellow:
                    return Colors.Yellow;
                case GameColor.Red:
                    return Colors.Red;
                default:
                    return Colors.White;
            }
        }
    }
}
