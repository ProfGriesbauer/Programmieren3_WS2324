using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace OOPGames
{
    public interface II_PlayerSpaceIn : IGamePlayer
    {
        
    }

    public interface II_RulesSpaceIn : IGameRules2
    {

    }

    public interface II_PaintSpaceIn : IPaintGame2 
    {

    }

    public interface II_MoveSpaceIn : IPlayMove
    {

    }
}
