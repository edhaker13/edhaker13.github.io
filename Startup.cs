using Blazor.Extensions.Logging;
using Blazor.Extensions.Storage;
using BlazorRedux;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorStandalone
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder => builder.AddBrowserConsole().SetMinimumLevel(LogLevel.Trace));
            services.AddReduxStore<MyState, IAction>(new MyState(), Reducers.RootReducer, options=>options.GetLocation=state=>state.Location);
            services.AddStorage();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
