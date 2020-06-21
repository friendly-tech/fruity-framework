using System;

namespace FruityFramework.ButtonInput
{
    public class ButtonClickedEventArgs: EventArgs
    {
        public Button Button { get; set; }
        public object CommandArguments { get; set; }
    }
}
