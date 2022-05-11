using Blazorise;
using Microsoft.AspNetCore.Components;

namespace Fathym.LCU.GuidedTour.WASM
{
    public class AppBase : ComponentBase
    {
        #region Fields
        protected readonly Theme theme;
        #endregion

        #region Constructors
        public AppBase()
        {
            theme = new Theme
            {
                ColorOptions = new ThemeColorOptions
                {
                    Primary = "#4a918e",
                    Secondary = "#b9dddd"
                }
            };
        }
        #endregion
    }
}