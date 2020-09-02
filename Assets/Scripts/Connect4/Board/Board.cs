using System.Collections.Generic;


/// <summary>
/// Board class
/// </summary>
public class Board
{

    /// <summary>
    /// Board constructor
    /// </summary>
    public Board()
    {
        Table = BoardUtils.GetDefaultBoard();
    }

    /// <summary>
    /// Constructor form another board
    /// </summary>
    /// <param name="board"></param>
    public Board(Tile[,] board)
    {
        Tile[,] boardCpy = new Tile[BoardUtils.NUM_ROWS, BoardUtils.NUM_COLS];
        for (int i = 0; i < BoardUtils.NUM_ROWS; i++)
        {
            for (int j = 0; j < BoardUtils.NUM_COLS; j++)
            {
                boardCpy[i, j] = board[i, j];
            }
        }
        Table = boardCpy;
    }

    #region Properties
    public Tile[,] Table { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Function to set a piece on the board
    /// </summary>
    /// <param name="column">column to set the piece on</param>
    /// <param name="playerAlliance">piece type</param>
    public void SetPiece(int column, PlayerAlliance playerAlliance)
    {
        if(column < 0 || column >= BoardUtils.NUM_COLS)
        {
            throw new InvalidColumnException();
        }
        int availableRow = BoardUtils.NUM_ROWS - 1;
        while(availableRow >= 0)
        {
            if(Table[availableRow, column] == Tile.EMPTY)
            {
                break;
            }
            availableRow--;
        }
     
        if (availableRow < 0)
        {
            throw new ColumnOccupiedException($"Column {column} is already occupied");
        }
        Table[availableRow, column] = playerAlliance == PlayerAlliance.RED ? Tile.RED : Tile.BLACK;
    }
    #endregion

    /// <summary>
    /// ToString override
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        string toRet = "Board\n";
        for(int i = 0; i<BoardUtils.NUM_ROWS; i++)
        {
            for(int j = 0; j < BoardUtils.NUM_COLS; j++)
            {
                toRet += Table[i, j] + " ";
            }
            toRet += "\n";
        }
        return toRet;
    }

    /// <summary>
    /// Function to get the valid moves 
    /// </summary>
    /// <returns>list of ints with valid columns</returns>
    public List<int> GetValidMoves()
    {
        List<int> validMoves = new List<int>();

        for(int i = 0; i<BoardUtils.NUM_COLS; i++)
        {
            if(Table[0,i] == Tile.EMPTY)
            {
                validMoves.Add(i);
            }
        }

        return validMoves;

    }

}