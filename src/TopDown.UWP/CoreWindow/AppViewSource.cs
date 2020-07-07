using Windows.ApplicationModel.Core;

namespace TopDown.UWP
{
    public class AppViewSource : IFrameworkViewSource
    {
        public IFrameworkView CreateView() => new AppView();
    }
}
