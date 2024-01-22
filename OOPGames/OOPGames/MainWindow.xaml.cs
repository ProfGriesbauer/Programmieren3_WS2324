using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Ein schöne Kommentar

namespace OOPGames
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IGamePlayer _CurrentPlayer = null;
        IPaintGame _CurrentPainter = null;
        IGameRules _CurrentRules = null;
        IGamePlayer _CurrentPlayer1 = null;
        IGamePlayer _CurrentPlayer2 = null;

        System.Windows.Threading.DispatcherTimer _PaintTimer = null;

        public MainWindow()
        {
            OOPGamesManager.Singleton.RegisterPlayer(new Pac_HumanPlayer());
            OOPGamesManager.Singleton.RegisterPainter(new Pac_Paint());
            OOPGamesManager.Singleton.RegisterRules(new Pac_Rules());
            //REGISTER YOUR CLASSES HERE
            OOPGamesManager.Singleton.RegisterPainter(new X_TicTacToePaintSHo());
            OOPGamesManager.Singleton.RegisterPainter(new C_Paint());
            OOPGamesManager.Singleton.RegisterRules(new C_Rules());
            OOPGamesManager.Singleton.RegisterPlayer(new C_HumanPlayer());           
            OOPGamesManager.Singleton.RegisterPlayer(new C_COMPlayer());


            //Painters
            OOPGamesManager.Singleton.RegisterPainter(new D_MinesweeperPainter());
            OOPGamesManager.Singleton.RegisterPainter(new I_Space_Invader_Painter());
            OOPGamesManager.Singleton.RegisterPainter(new S_MinesweeperPainter());
            OOPGamesManager.Singleton.RegisterPainter(new S20_MinesweeperPainter());
            OOPGamesManager.Singleton.RegisterPainter(new X_TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new E_TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new VierGewinntGruppeBPaint());
            OOPGamesManager.Singleton.RegisterPainter(new A_TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new A_MühlePaint());

            //Rules
            OOPGamesManager.Singleton.RegisterRules(new D_MinesweeperRules());
            OOPGamesManager.Singleton.RegisterRules(new X_TicTacToeRulesSH());
            OOPGamesManager.Singleton.RegisterRules(new I_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new X_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new S_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new E_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new Space_Invaders_Rules());
            OOPGamesManager.Singleton.RegisterRules(new VierGewinntGruppeBRules());
			OOPGamesManager.Singleton.RegisterRules(new A_TicTacToeRules());
           
            OOPGamesManager.Singleton.RegisterRules(new A_MühleRules());


            //Players
            OOPGamesManager.Singleton.RegisterPlayer(new D_player());
            OOPGamesManager.Singleton.RegisterPlayer(new X_TicTacToeHumanPlayerSH());
            OOPGamesManager.Singleton.RegisterPlayer(new X_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new X_TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new S_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new S_TicTacToeComputerPlayer());            
            OOPGamesManager.Singleton.RegisterPlayer(new I_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new I_TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new E_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new E_TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new Space_Invaders_Player());
			OOPGamesManager.Singleton.RegisterPlayer(new A_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new VierGewinntGruppeBPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new A_TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new VierGewinntGruppeBComputer());
            OOPGamesManager.Singleton.RegisterPlayer(new A_TicTacToeComputerPlayer2());
            OOPGamesManager.Singleton.RegisterPlayer(new A_HumanMühlePlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new A_MühleComputerPlayer());





            InitializeComponent();
            PaintList.ItemsSource = OOPGamesManager.Singleton.Painters;
            Player1List.ItemsSource = OOPGamesManager.Singleton.Players;
            Player2List.ItemsSource = OOPGamesManager.Singleton.Players;
            RulesList.ItemsSource = OOPGamesManager.Singleton.Rules;

            _PaintTimer = new System.Windows.Threading.DispatcherTimer();
            _PaintTimer.Interval = new TimeSpan(0, 0, 0, 0, 40);
            _PaintTimer.Tick += _PaintTimer_Tick;
            _PaintTimer.Start();
        }

        private void _PaintTimer_Tick(object sender, EventArgs e)
        {
            if (_CurrentPainter != null &&
                _CurrentRules != null)
            {
                if (_CurrentPainter is IPaintGame2 &&
                    _CurrentRules.CurrentField != null &&
                    _CurrentRules.CurrentField.CanBePaintedBy(_CurrentPainter))
                {
                    ((IPaintGame2)_CurrentPainter).TickPaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                }

                if (_CurrentRules is IGameRules2)
                {
                    ((IGameRules2)_CurrentRules).TickGameCall();
                }
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            List<IGamePlayer> activePlayers = new List<IGamePlayer>();
            _CurrentPlayer1 = null;
            if (Player1List.SelectedItem is IGamePlayer)
            {
                _CurrentPlayer1 = ((IGamePlayer)Player1List.SelectedItem).Clone();
                _CurrentPlayer1.SetPlayerNumber(1);
                activePlayers.Add(_CurrentPlayer1);
            }
            _CurrentPlayer2 = null;
            if (Player2List.SelectedItem is IGamePlayer)
            {
                _CurrentPlayer2 = ((IGamePlayer)Player2List.SelectedItem).Clone();
                _CurrentPlayer2.SetPlayerNumber(2);
                activePlayers.Add(_CurrentPlayer2);
            }

            _CurrentPlayer = null;
            _CurrentPainter = PaintList.SelectedItem as IPaintGame;
            _CurrentRules = RulesList.SelectedItem as IGameRules;

            OOPGamesManager.Singleton.RegisterActivePlayers(activePlayers);
            OOPGamesManager.Singleton.RegisterActivePainter(_CurrentPainter);
            OOPGamesManager.Singleton.RegisterActiveRules(_CurrentRules);

            if (_CurrentRules is IGameRules2)
            {
                ((IGameRules2)_CurrentRules).StartedGameCall();
            }

            if (_CurrentPainter != null && 
                _CurrentRules != null && _CurrentRules.CurrentField.CanBePaintedBy(_CurrentPainter))
            {
                _CurrentPlayer = _CurrentPlayer1;
                Status.Text = "Game startet!";
                Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                _CurrentRules.ClearField();
                _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                //try {
                DoComputerMoves();
                //}

                /*
                catch (Exception e) {}      fängt die Exception und tut nichts
                                            setz bei Try wieder ein
                */
            }
        }

        private void DoComputerMoves()
        {
            int winner = _CurrentRules.CheckIfPLayerWon();
            if (_CurrentRules is IGameRules3 &&
                ((IGameRules3)_CurrentRules).CheckIfDraw())
            {
                Status.Text = "Draw Game!";
            }
            else if (winner > 0)
            {
                Status.Text = "Player " + winner + " Won!";
            }
            else
            {
                while (_CurrentRules.MovesPossible &&
                       winner <= 0 &&
                       _CurrentPlayer is IComputerGamePlayer)
                {
                    IPlayMove pm = ((IComputerGamePlayer)_CurrentPlayer).GetMove(_CurrentRules.CurrentField);
                    if (pm != null)
                    {
                        _CurrentRules.DoMove(pm);
                        _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                        _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                        Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                    }

                    winner = _CurrentRules.CheckIfPLayerWon();
                    if (_CurrentRules is IGameRules3 &&
                        ((IGameRules3)_CurrentRules).CheckIfDraw())
                    {
                        Status.Text = "Draw Game!";
                    }
                    else if (winner > 0)
                    {
                        Status.Text = "Player " + winner + " Won!";
                    }
                }
            }
        }

        private void PaintCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Sonderfall für das Mühle Spiel
            if (_CurrentRules is IA_MühleRules)
            {
                int mühlewinner = _CurrentRules.CheckIfPLayerWon();
                if (_CurrentRules is IGameRules3 &&
                   ((IGameRules3)_CurrentRules).CheckIfDraw())
                {
                    Status.Text = "Draw Game!";
                }
                else if (mühlewinner > 0)
                {
                    Status.Text = "Player " + mühlewinner + " Won!";
                }
                else
                {
                    if (_CurrentRules.MovesPossible &&
                        _CurrentPlayer is A_HumanMühlePlayer)
                    {
                        IPlayMove pm = ((A_HumanMühlePlayer)_CurrentPlayer).GetMove(new ClickSelection((int)e.GetPosition(PaintCanvas).X,
                            (int)e.GetPosition(PaintCanvas).Y, (int)e.ChangedButton), _CurrentRules.CurrentField);

                        if (pm != null)
                        {
                            _CurrentRules.DoMove(pm);
                            _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                            _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                            Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                        }

                        DoComputerMoves();
                    }
                }
            }
            else
            {
                int winner = _CurrentRules.CheckIfPLayerWon();
                if (_CurrentRules is IGameRules3 &&
                   ((IGameRules3)_CurrentRules).CheckIfDraw())
                {
                    Status.Text = "Draw Game!";
                }
                else if (winner > 0)
                {
                    Status.Text = "Player " + winner + " Won!";
                }
                else
                {
                    if (_CurrentRules.MovesPossible &&
                        _CurrentPlayer is IHumanGamePlayer)
                    {
                        IPlayMove pm = ((IHumanGamePlayer)_CurrentPlayer).GetMove(new ClickSelection((int)e.GetPosition(PaintCanvas).X,
                            (int)e.GetPosition(PaintCanvas).Y, (int)e.ChangedButton), _CurrentRules.CurrentField);
                        if (pm != null)
                        {
                            _CurrentRules.DoMove(pm);
                            _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                            _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                            Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                        }

                        DoComputerMoves();
                    }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _PaintTimer.Tick -= _PaintTimer_Tick;
            _PaintTimer.Stop();
            _PaintTimer = null;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_CurrentRules == null) return;
            int winner = _CurrentRules.CheckIfPLayerWon();
            if (_CurrentRules is IGameRules3 &&
               ((IGameRules3)_CurrentRules).CheckIfDraw())
            {
                Status.Text = "Draw Game!";
            }
            else if (winner > 0)
            {
                Status.Text = "Player" + winner + " Won!";
            }
            else
            {
                if (_CurrentRules.MovesPossible &&
                    _CurrentPlayer is IHumanGamePlayer)
                {
                    IPlayMove pm = ((IHumanGamePlayer)_CurrentPlayer).GetMove(new KeySelection(e.Key), _CurrentRules.CurrentField);
                    if (pm != null)
                    {
                        _CurrentRules.DoMove(pm);
                        _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                        Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                    }

                    DoComputerMoves();
                }
            }
        }
    }
}
