namespace Chess.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ChessBoardViewModel ChessBoardViewModel { get; } = new ChessBoardViewModel();
}