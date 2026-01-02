using System;

namespace Chess.ViewModels;

public class Horse: Figure
{
    public const string SpritePath = "avares://Chess/Assets/images/horse_black.png";
    
    public Horse(int x, int y, int tileSize) : base(x, y, tileSize, SpritePath)
    {
    }

    public override bool CheckMove(int newX, int newY)
    {
        return (Math.Abs(X + 1 - (newX + 1)) == 1 && Math.Abs(Y + 1 - (newY + 1)) == 2) ||
                (Math.Abs(X + 1 - (newX + 1)) == 2 && Math.Abs(Y + 1 - (newY + 1)) == 1);
    }
}