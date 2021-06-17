using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.LifecycleEvents;
using Telerik.Maui;
using Telerik.Maui.Handlers;

#if __ANDROID__
using InputRenderer = Telerik.XamarinForms.InputRenderer.Android;
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.Android;
using PrimitivesRenderer = Telerik.XamarinForms.PrimitivesRenderer.Android;
#elif __IOS__
using InputRenderer = Telerik.XamarinForms.InputRenderer.iOS;
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.iOS;
using PrimitivesRenderer = Telerik.XamarinForms.PrimitivesRenderer.iOS;
#else
using ChartRenderer = Telerik.XamarinForms.ChartRenderer.UWP;
using InputRenderer = Telerik.XamarinForms.InputRenderer.UWP;
using PrimitivesRenderer = Telerik.XamarinForms.PrimitivesRenderer.UWP;
#endif

namespace HelloMaui
{
    public class Startup : IStartup
    {
        public void Configure(IAppHostBuilder appBuilder)
        {
            appBuilder
                .UseMauiApp<App>()
                //.UseFormsCompatibility()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("ionicons.ttf", "IonIcons");
                })
                .ConfigureMauiHandlers(handlers => {
                    handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Input.RadButton), typeof(InputRenderer.ButtonRenderer));
                    handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Chart.RadCartesianChart), typeof(ChartRenderer.CartesianChartRenderer));
                    handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Input.RadSegmentedControl), typeof(InputRenderer.SegmentedControlRenderer));
                    handlers.AddCompatibilityRenderer(typeof(Telerik.XamarinForms.Primitives.RadCheckBox), typeof(PrimitivesRenderer.CheckBoxRenderer));
                    handlers.AddHandler<IRadItemsControl, RadItemsControlHandler>();
                    handlers.AddHandler<IRadBorder, RadBorderHandler>();
                })
                
                .ConfigureLifecycleEvents(lifecycle => {
#if ANDROID
                    lifecycle.AddAndroid(d => {
                        d.OnBackPressed(activity => {
                            System.Diagnostics.Debug.WriteLine("Back button pressed!");
                        });
                    });
#endif
                });
        }
    }
}