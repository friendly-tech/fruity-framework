using System.Threading.Tasks;

namespace FruityFramework.ButtonInput
{
    public class Button
    {
        public string CommandName { get; set; }
        internal ButtonSet ButtonSet { get; set; }

        public async Task Click()
        {
            await ButtonSet?.InputReceiver?.OnButtonClicked(this);
        }
    }
}
