using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using System;
using System.Numerics;
using TopDown.Core;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Core;

namespace TopDown.UWP
{
    public class Renderer
    {
        private readonly CoreWindow _window;
        private readonly CanvasDevice _canvasDevice;
        private readonly CanvasSwapChain _swapChain;
        private readonly FPSCounter _fps;
        public Renderer(CoreWindow window)
        {
            _window = window;

            _canvasDevice = new CanvasDevice();

            float dpi = DisplayInformation.GetForCurrentView().LogicalDpi;

            _swapChain = CanvasSwapChain.CreateForCoreWindow(_canvasDevice, window, dpi);

            _fps = new FPSCounter();
        }

        public void Render(Action<ICanvas> gameDraw)
        {
            _fps.Frame();

            
            using (CanvasDrawingSession ds = _swapChain.CreateDrawingSession(Colors.Black))
            {
                ds.DrawText("FPS: " + _fps.FPS, new Vector2(10, 10), Colors.Red, new CanvasTextFormat
                {
                    FontSize = 50
                });

                gameDraw(new DrawingSessionCanvas(ds));
            }

            _swapChain.Present();
        }

        public void Trim() => _canvasDevice.Trim();
    }
}
