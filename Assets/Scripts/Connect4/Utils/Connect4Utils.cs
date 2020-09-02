using System;
/// <summary>
/// Class for utilitaries such as game over
/// </summary>
class Connect4Utils
{

    //constants
    public static double INF =  double.PositiveInfinity;
    public static double NEG_INF = double.NegativeInfinity;


    /// <summary>
    /// Function which checks if the game is finished
    /// </summary>
    /// <param name="board">board to be checked</param>
    /// <returns></returns>
    public static bool Finished(Board board)
    {
        return FinishedVertically(board) || FinishedHorizontally(board) || FinishedDiagonal(board);
    }

    /// <summary>
    /// Function to check if the game is done on a vertical line
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    private static bool FinishedVertically(Board board)
    {
        var table = board.Table;
        for(int col = 0; col < BoardUtils.NUM_COLS; col++)
        {
            for(int row = 0; row < BoardUtils.NUM_ROWS - 3; row++)
            {
                if(table[row, col] == table[row + 1, col] && table[row + 1, col] == table[row + 2, col] && table[row + 2, col] == table[row + 3, col] && table[row, col] != Tile.EMPTY)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Function to check if the game is done on a horizontal line
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    private static bool FinishedHorizontally(Board board)
    {
        var table = board.Table;
        for(int row = 0; row < BoardUtils.NUM_ROWS; row++)
        {
            for(int col = 0; col < BoardUtils.NUM_COLS - 3; col++)
            {
                if(table[row, col] == table[row, col + 1] && table[row, col + 1] == table[row, col + 2] && table[row, col + 2] == table[row, col + 3] && table[row, col] != Tile.EMPTY)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Function to check if te game is done on diagonal
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    private static bool FinishedDiagonal(Board board)
    {
        var table = board.Table;
        for(int row = 0; row < BoardUtils.NUM_ROWS; row++)
        {
            for(int col = 0; col < BoardUtils.NUM_COLS; col++)
            {
                if(row + 3 < BoardUtils.NUM_ROWS && col + 3 < BoardUtils.NUM_COLS)
                {
                    if(table[row, col] == table[row + 1, col + 1] && table[row + 1, col + 1] == table[row + 2, col + 2] && table[row + 2, col + 2] == table[row + 3, col + 3] && table[row, col] != Tile.EMPTY)
                    {
                        return true;
                    }
                }
                if (row + 3 < BoardUtils.NUM_ROWS && col - 3 >= 0)
                {
                    if (table[row, col] == table[row + 1, col - 1] && table[row + 1, col - 1] == table[row + 2, col - 2] && table[row + 2, col - 2] == table[row + 3, col - 3] && table[row, col] != Tile.EMPTY)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public static EndGameCoordintaes GetEndGameCoordinates(Board board)
    {
        if (!Finished(board))
        {
            throw new GameNotFinishedException();
        }

        var table = board.Table;
        for (int col = 0; col < BoardUtils.NUM_COLS; col++)
        {
            for (int row = 0; row < BoardUtils.NUM_ROWS - 3; row++)
            {
                if (table[row, col] == table[row + 1, col] && table[row + 1, col] == table[row + 2, col] && table[row + 2, col] == table[row + 3, col] && table[row, col] != Tile.EMPTY)
                {
                    return new EndGameCoordintaes(col, col, row, row + 3);
                }
            }
        }

        for (int row = 0; row < BoardUtils.NUM_ROWS; row++)
        {
            for (int col = 0; col < BoardUtils.NUM_COLS - 3; col++)
            {
                if (table[row, col] == table[row, col + 1] && table[row, col + 1] == table[row, col + 2] && table[row, col + 2] == table[row, col + 3] && table[row, col] != Tile.EMPTY)
                {
                    return new EndGameCoordintaes(col, col + 3, row, row);
                }
            }
        }

        for (int row = 0; row < BoardUtils.NUM_ROWS; row++)
        {
            for (int col = 0; col < BoardUtils.NUM_COLS; col++)
            {
                if (row + 3 < BoardUtils.NUM_ROWS && col + 3 < BoardUtils.NUM_COLS)
                {
                    if (table[row, col] == table[row + 1, col + 1] && table[row + 1, col + 1] == table[row + 2, col + 2] && table[row + 2, col + 2] == table[row + 3, col + 3] && table[row, col] != Tile.EMPTY)
                    {
                        return new EndGameCoordintaes(col, col + 3, row, row + 3);
                    }
                }
                if (row + 3 < BoardUtils.NUM_ROWS && col - 3 >= 0)
                {
                    if (table[row, col] == table[row + 1, col - 1] && table[row + 1, col - 1] == table[row + 2, col - 2] && table[row + 2, col - 2] == table[row + 3, col - 3] && table[row, col] != Tile.EMPTY)
                    {
                        return new EndGameCoordintaes(col, col - 3, row, row + 3);
                    }
                }
            }
        }
        throw new GameNotFinishedException();
    }

}

