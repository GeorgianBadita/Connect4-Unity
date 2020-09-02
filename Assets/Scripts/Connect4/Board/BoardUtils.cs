
/// <summary>
/// Class for board utilitaries
/// </summary>
public class BoardUtils
{
    //board dimensions
    public static readonly int NUM_ROWS = 6;
    public static readonly int NUM_COLS = 7;

    //matrix for evaluatiing a board position
    private static int[,] evaluationBoard = new int[,]{
        {3, 4, 5, 7, 5, 4, 3},
        {4, 6, 8, 10, 8, 6, 4},
        {5, 8, 11, 13, 11, 8, 5},
        {5, 8, 11, 13, 11, 8, 5},
        {4, 6, 8, 10, 8, 6, 4},
        {3, 4, 5, 7, 5, 4, 3}
    };

    /// <summary>
    /// Function for getting the deault  empty board
    /// </summary>
    /// <returns>the default empty board for Connect4</returns>
    public static Tile[,] GetDefaultBoard()
    {
        Tile[,] board = new Tile[NUM_ROWS, NUM_COLS];
        for (int i = 0; i < NUM_ROWS; i++)
        {
            for (int j = 0; j < NUM_COLS; j++)
            {
                board[i, j] = Tile.EMPTY;
            }
        }

        return board;
    }

    /// <summary>
    /// Function to evaluate a board from the given player perspective
    /// </summary>
    /// <param name="board"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    public static double EvaluateBoard(Board board, PlayerAlliance alliance)
    {
        if (Connect4Utils.Finished(board))
        {
            return Connect4Utils.INF;
        }

        double score = 0;
        for (int i = 0; i < NUM_ROWS; i++)
        {
            for (int j = 0; j < NUM_COLS; j++)
            {
                if (board.Table[i, j] != Tile.EMPTY)
                {
                    if (board.Table[i, j] == Tile.RED && alliance == PlayerAlliance.RED)
                    {
                        score += evaluationBoard[i, j];
                    }
                    else if (board.Table[i, j] == Tile.BLACK && alliance == PlayerAlliance.BLACK)
                    {
                        score += evaluationBoard[i, j];
                    }
                }
            }
        }

        return score;
    }
}