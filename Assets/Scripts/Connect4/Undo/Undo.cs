using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Undo
{
    //stack vor retaining the moves
    private Stack<Memento> undoStack;

    public Undo()
    {
        undoStack = new Stack<Memento>();
    }

    #region Methods
    /// <summary>
    /// Function to get the last memento from the stack
    /// </summary>
    /// <returns></returns>
    public Memento GetLastGameState()
    {
        if(undoStack.Count > 0)
        {
            return undoStack.Pop();
        }
        throw new EmptyUndoStackException();
    }

    /// <summary>
    /// Function to add a new move to the memento stack
    /// </summary>
    /// <param name="currentState"></param>
    public void AddMementoToStack(Memento currentState)
    {
        undoStack.Push(currentState);
    }

    /// <summary>
    /// Function for getting the number of undo entries in the undo stack
    /// </summary>
    public int Size()
    {
        return undoStack.Count;
    }
    #endregion 
}

