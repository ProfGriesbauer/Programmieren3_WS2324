using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    public class Lasse_Moeller_PainterMinesweeper: IPaintGame2
    {
        public string Name { get { return "Minesweeper_Painter_D"; } }

        string IPaintGame.Name => throw new NotImplementedException();

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            throw new NotImplementedException();
        }

        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            throw new NotImplementedException();
        }
    }
}
