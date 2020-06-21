using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruityFramework.ButtonInput
{
    public class ButtonSet
    {
        public IEnumerable<Button> Buttons { get; set; }
        public event EventHandler<ButtonClickedEventArgs> ButtonClicked;
        public void ClickButton(string commandName, object commandArgument = null)
        {
            Buttons.Single(b => b.CommandName == commandName).Click(commandArgument);
        }
        public ButtonSet(IEnumerable<Button> buttons)
        {
            foreach (var btn in buttons)
            {
                btn.ButtonSet = this;
                btn.Clicked += (sender, args) =>
                {
                    ButtonClicked?.Invoke(this, args);
                };
            }
            Buttons = buttons;
        }

    }
}
