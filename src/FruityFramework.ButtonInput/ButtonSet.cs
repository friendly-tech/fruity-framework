using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruityFramework.ButtonInput
{
    public class ButtonSet
    {

        public async Task ClickButton(string commandName)
        {
            await Buttons.Single(b => b.CommandName == commandName).Click();
        }
        public ButtonSet(IEnumerable<Button> buttons)
        {
            foreach (var btn in buttons)
            {
                btn.ButtonSet = this;
            }

            Buttons = buttons;
        }
        public IEnumerable<Button> Buttons { get; set; }
        public IButtonInputReceiver InputReceiver { get; set; }
    }
}
