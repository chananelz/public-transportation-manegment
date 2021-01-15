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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;




namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for board.xaml
    /// </summary>
    public partial class board : Window
    {
        BO.Stop stop = new BO.Stop();

        public static BO.Board nothing = null;//have to send a sender!!!!! and is always null

        public static event EventHandler<BO.Board> BoardChanged;


        private static void UpdateBoard(long number, long stopCode)
        {
            BoardChanged?.Invoke(nothing, new BO.Board(number,stopCode));
        }


        public board(BO.Stop myStop)
        {
            InitializeComponent();
            stop = myStop;
            LineListS.DataContext = myStop.Lines;
            boardList.DataContext = stop.Boards;
            board.BoardChanged += changeText;
        }


        private void changeText(object sender, BO.Board args)
        {
            //foreach(var a in boardList.Items)
            //{
            //    if((a as BO.Board).Number == args.Number)
                    
            //}
            //boardList.DataContext = args. as ;
        }


        private void UpdateBoardList()
        {
            //stop.Boards
        }



    }
}
