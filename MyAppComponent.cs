using BlazorRedux;
using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorStandalone
{
    public class MyAppComponent : ReduxComponent<MyState, IAction>
    {
        [Inject]
        protected ILogger<MyAppComponent> Logger {get;set;}
        [Inject]
        protected LocalStorage LocalStorage {get;set;}
        [Inject]
        protected SessionStorage SessionStorage {get;set;}
    }
}