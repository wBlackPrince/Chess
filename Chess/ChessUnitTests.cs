using Avalonia.Headless.XUnit;
using Chess.ViewModels;
using Chess.Views;

namespace Chess;

public class ChessUnitTests
{
    [AvaloniaFact]
    public void Should_MovePawn()
    {
        // Arrange
        var window = new MainWindow()
        {
            DataContext = new MainWindowViewModel()
        };

        // рендерим окно и получаем viewModel
        window.Show();
        var viewModel = (MainWindowViewModel)window.DataContext;
        
        // добавляем пешку на поле
        Pawn pawn = new Pawn(4, 3, ChessBoardViewModel.TileSize);
        viewModel.ChessBoardViewModel.Figures.Add(pawn);
        
        // TODO
        
    }
}