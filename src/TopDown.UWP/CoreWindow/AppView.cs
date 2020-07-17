using System.Diagnostics;
using TopDown.Core;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;

namespace TopDown.UWP
{
    public class AppView : IFrameworkView
    {
        private const int RenderInterval = 16;
        private const int GameInterval = 8;
        private Renderer _renderer;
        private readonly Stopwatch _sw = Stopwatch.StartNew();
        private long _targetRender = 0;
        private long _targetGame = 0;
        private long _lastGameUpdate = 0;
        private Game _game;

        public void Initialize(CoreApplicationView applicationView)
        {
            applicationView.Activated += (sender, args) => CoreWindow.GetForCurrentThread().Activate();
            ApplicationViewScaling.TrySetDisableLayoutScaling(true);
        }

        public void SetWindow(CoreWindow window)
        {
            window.PointerCursor = null;
            _renderer = new Renderer(window);
            UWPInput input = new UWPInput(window);
            _game = new Game(input);
        }

        public void Load(string entryPoint)
        {
        }

        public void Run()
        {
            while(true)
            {
                long current = _sw.ElapsedMilliseconds;
                if(current > _targetRender)
                {
                    _renderer?.Render(_game.Render);
                    _targetRender = current + RenderInterval;
                }

                current = _sw.ElapsedMilliseconds;
                if (current > _targetGame)
                {
                    int delta = (int)(current - _lastGameUpdate);
                    _game?.Update(delta / 1000.0f);
                    _targetGame = current + GameInterval;
                    _lastGameUpdate = current;
                }

                CoreWindow.GetForCurrentThread().Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessAllIfPresent);
            }
        }

        public void Uninitialize()
        {
        }
    }
}
