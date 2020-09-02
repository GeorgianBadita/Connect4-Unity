using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Class for retaining the game state
/// </summary>
public class Memento
{
    public Memento(Player currentPlayer, Board board, GameObject piece)
    {
        CurrentPlayer = currentPlayer;
      
        Piece = piece;
        Board = new Board(board.Table);
    }

    #region Properties
    public Player CurrentPlayer { get; }
    public Board Board { get; }

    public GameObject Piece { get; }
    #endregion
}

