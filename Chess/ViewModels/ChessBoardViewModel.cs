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
        
        Pawn a = new Pawn(4, 3, TileSize);
        
        Figures.Add(a);

        Pawn b = new Pawn(5, 6, TileSize);
        
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
        Console.WriteLine($"Move called: OldX={OldX}, OldY={OldY}, NewX={NewX}, NewY={NewY}");
        Console.WriteLine($"Calculated old coordinates: X={OldX}, Y={OldY}");

        for (int i = 0; i < Figures.Count; i++)
        {
            if (Figures[i].X == OldX && Figures[i].Y == OldY && Figures[i].CheckMove(NewX, NewY))
            {
                Console.Write($"Pawn matched! Moving to X={NewX}, Y={NewY}    ");
                Console.WriteLine($"Type of chosen figure: {Figures[i].GetType().Name}'");
                Figures[i] = new Pawn(NewX, NewY, TileSize);
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