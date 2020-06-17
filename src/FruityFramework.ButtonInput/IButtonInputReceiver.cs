using System.Threading.Tasks;

namespace FruityFramework.ButtonInput
{
    /// <summary>
    /// Something that can receive button inputs
    /// </summary>
    public interface IButtonInputReceiver
    {
        Task OnButtonClicked(Button button);
    }
}
