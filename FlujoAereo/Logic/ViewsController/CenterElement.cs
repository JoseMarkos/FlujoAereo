using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class CenterElement
    {
        public int Horizontal(int elementWidth, int containerWidth)
        {
            return (containerWidth / 2) - (elementWidth / 2);
        }

        public int Vertical(int elementHeight, int containerHeight)
        {
            return (containerHeight / 2) - (elementHeight / 2);
        }
    }
}
