/// <summary>
/// Class for Player
/// </summary>

public class Player
{

    /// <summary>
    /// Constructor for Player class
    /// </summary>
    /// <param name="playerType">player type (HUMAN, COMPUTER)</param>
    /// <param name="pieceAlliance">piece alliance (RED, BLACK)</param>
    public Player(PlayerType playerType, PlayerAlliance pieceAlliance)
    {
        Type = playerType;
        Alliance = pieceAlliance;
    }

    #region Properties
    public PlayerType Type {get; set;}
    
    public PlayerAlliance Alliance { get; set; }
    #endregion
}
