using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;

namespace Fathym.LCU.GuidedTour
{
    public class HeadShimBase : ComponentBase
    {
        #region Inject
        [Inject]
        protected virtual IHttpClientFactory? httpClientFactory { get; set; }

        [Inject]
        protected virtual ConfigUtilsJsInterop? configUtils { get; set; }

        [Inject]
        protected virtual HttpClient? localClient { get; set; }
        #endregion

        #region Fields
        protected string inlinedContent;
        #endregion

        #region Properties
        [Parameter]
        public virtual List<string> CSS { get; set; }

        [Parameter]
        public virtual List<string> JS { get; set; }

        [Parameter]
        public virtual string ScriptID { get; set; }
        #endregion

        #region Constructors
        public HeadShimBase()
        {
            inlinedContent = "";

            CSS = new List<string>();

            JS = new List<string>();

            ScriptID = "";
        }
        #endregion

        #region Life Cycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await configUtils!.InjectHeadScript(inlinedContent, ScriptID, true);
        }

        protected override async Task OnParametersSetAsync()
        {
            var jsInlines = JS.ToDictionary(js => js, js => "");

            var jsTasks = JS.Select(js => Task.Run(async () =>
            {
                try
                {

                    var client = js.StartsWith("http") ? httpClientFactory!.CreateClient() : localClient!;

                    var lookupPath = js.StartsWith("./") ? js.Substring(2) : js.StartsWith("/") ? js.Substring(1) : js;

                    var jsRes = await client.GetStringAsync(lookupPath);

                    lock (jsInlines)
                        jsInlines[js] = jsRes;
                }
                catch (Exception ex)
                {
                    //  TODO: Log
                }
            }));

            await Task.WhenAll(jsTasks);

            var inlines = jsInlines.Select(js => js.Value).ToList();

            var inlined = new StringBuilder();

            inlines.ForEach(inline =>
            {
                inlined.AppendLine(inline);
            });

            inlinedContent = inlined.ToString();

            await base.OnParametersSetAsync();
        }
        #endregion
    }
}