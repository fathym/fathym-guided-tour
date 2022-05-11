using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;

namespace Fathym.LCU.GuidedTour.WASM.Shared.Shims
{
    public class BlazoriseShimBase : ComponentBase
    {
        #region Inject
        #endregion

        #region Fields
        #endregion

        #region Properties
        [Parameter]
        public virtual List<string> CSS { get; set; }

        [Parameter]
        public virtual List<string> JS { get; set; }
        #endregion

        #region Constructors
        public BlazoriseShimBase()
        {
            CSS = new List<string>
            {
                "https://cdn.fathym.com/npm/djibe-material/css/material.min.css",
                "https://fonts.googleapis.com/css?family=Roboto:300,300i,400,400i,500,500i,700,700i|Roboto+Mono:300,400,700|Roboto+Slab:300,400,700",
                "https://fonts.googleapis.com/icon?family=Material+Icons",
                "./_content/Blazorise/blazorise.css",
                "./_content/Blazorise.Material/blazorise.material.css",
                "./_content/Blazorise.Icons.Material/blazorise.icons.material.css"
            };

            JS = new List<string>
            {
                "https://code.jquery.com/jquery-3.3.1.slim.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js",
                "https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js",
                "https://cdn.fathym.com/npm/djibe-material/js/material.min.js",
                "./_content/Blazorise.Material/blazorise.material.js"
            };
        }
        #endregion

        #region Life Cycle
        #endregion
    }
}