using System;
using System.Threading.Tasks;

namespace FruityFramework.ButtonInput
{
    public class Button
    {
        public event EventHandler<ButtonClickedEventArgs> Clicked;

        public static Button Cancel()
        {
            return new Button { CommandName = WellKnownCommandNames.Cancel};
        }

        public static Button Start()
        {
            return new Button { CommandName = WellKnownCommandNames.Start};
        }
        public string CommandName { get; set; }
        internal ButtonSet ButtonSet { get; set; }

        public void Click(object commandArgument)
        {
            Clicked?.Invoke(this, new ButtonClickedEventArgs()
            {
                Button = this,
                CommandArguments = commandArgument
            });
        }
    }
}
