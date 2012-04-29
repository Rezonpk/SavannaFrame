using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannaFrame.Classes
{
    class MLV
    {
        // Тут типа описание логического вывода для продукций тут вывод непосредственно

        public void doMLVForPoint(GameCell gameCell)
        {
            FrameExample situationExample = new FrameExample();
            situationExample.SetValue("agent", gameCell.FrameExample);

        }
    }
}
