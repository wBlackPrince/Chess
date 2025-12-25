using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;

namespace Chess.ViewModels;

public partial class ChessBoardViewModel: ReactiveObject
{
    public static int TileSize = 70;

    public ObservableCollection<Pawn> Figures { get; set; } = [];
    
    public ObservableCollection<Tile> Tiles { get; set; } = [];

    public ChessBoardViewModel()
    {
        MoveCommand = ReactiveCommand.Create(Move);
        
        Pawn a = new Pawn(
            4 * TileSize + TileSize/4,
            3 * TileSize + TileSize/4);
        
        Figures.Add(a);

        Pawn b = new Pawn(
            5 * TileSize + TileSize/4,
            6 * TileSize + TileSize/4);
        
        Figures.Add(b);
        
        a.PrintCoords();
        b.PrintCoords();
        

        for (int i = 0; i < 64; i++)
        {
            Tile cell = new Tile(
                new SolidColorBrush((((i % 8) + (i / 8)) % 2 == 0) ? Colors.White : Colors.Black),
                (i % 8) * TileSize,
                (i / 8) * TileSize,
                TileSize); 
            
            Tiles.Add(cell);
        }
    }


    public ICommand MoveCommand { get; }

    public void Move()
    {
        int oldXCoord = OldX * TileSize + TileSize / 4;
        int oldYCoord = OldY * TileSize + TileSize / 4;
        
        Console.WriteLine($"Move called: OldX={OldX}, OldY={OldY}, NewX={NewX}, NewY={NewY}");
        Console.WriteLine($"Calculated old coordinates: X={oldXCoord}, Y={oldYCoord}");

        for (int i = 0; i < Figures.Count; i++)
        {
            if (Figures[i].X == oldXCoord && Figures[i].Y == oldYCoord)
            {
                Console.WriteLine($"Pawn matched! Moving to X={NewX * TileSize + TileSize / 4}, Y={NewY * TileSize + TileSize / 4}");
                Figures[i] = new Pawn(NewX * TileSize + TileSize / 4, NewY * TileSize + TileSize / 4);
            }
        }
    }
    
    
    private int _oldX = 0;
    public int OldX
    {
        get
        {
            return _oldX;
        }
        set
        {
            _oldX = value;
            this.RaiseAndSetIfChanged(ref _oldX, value);
        }
    }
    
    
    private int _oldY = 0;
    public int OldY
    {
        get
        {
            return _oldY;
        }
        set
        {
            _oldY = value;
            this.RaiseAndSetIfChanged(ref _oldY, value);
        }
    }
    
    
    private int _newX = 0;
    public int NewX
    {
        get
        {
            return _newX;
        }
        set
        {
            _newX = value;
            this.RaiseAndSetIfChanged(ref _newX, value);
        }
    }
    
    
    private int _newY = 0;
    public int NewY
    {
        get
        {
            return _newY;
        }
        set
        {
            _newX = value;
            this.RaiseAndSetIfChanged(ref _newY, value);
        }
    }
}