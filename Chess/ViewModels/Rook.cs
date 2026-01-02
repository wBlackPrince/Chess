namespace Chess.ViewModels;

public class Rook: Figure
{
    public const string SpritePath = "avares://Chess/Assets/images/rook_black.png";
    
    public Rook(int x, int y, int tileSize) : base(x, y, tileSize, SpritePath)
    {
    }

    public override bool CheckMove(int newX, int newY)
    {
        return (X == newX || Y == newY);
    }
}