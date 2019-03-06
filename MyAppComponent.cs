using BlazorRedux;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorStandalone
{
    public class MyAppComponent : ReduxComponent<MyState, IAction>
    {
        [Inject]
        protected ILogger<MyAppComponent> Logger {get;set;}
    }
}