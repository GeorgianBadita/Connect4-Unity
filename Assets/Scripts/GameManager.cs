using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //Pieces prefab
    public GameObject RedPiecePrefab;
    public GameObject BlackPiecePrefab;

    //winner text
    public GameObject WinnerText;

    //current player
    private Player currentPlayer;

    //y coordinates
    private float[] yCoordinates = new float[] { -3.319f, -1.9f, -0.486f, 0.933f, 2.348f, 3.767f };

    //x coordinates 
    private float[] xCoordinates = new float[] { -4.25f, -2.7914f, -1.3306f, 0.128f, 1.5826f, 3.0434f, 4.502f};

    //piece starting pos
    private float pieceStartingY = 8.00f;

    //Undo object
    private Undo undoStack;


    //variable for gamingEnd
    private bool IsGameOver;

    //end game line details
    private const float lineSize = 0.3f;
    public Material LineMaterial;

    //MiniMaxAi
    private MinMax MinMaxAI;

    //Function to start ai move after rendering ui changes
    private bool RenderingDone;

    //Difficulty
    private int Difficulty;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = new Player(PlayerType.HUMAN, PlayerAlliance.RED);
        currentPlayer = Player1;
        Player2 = new Player(PlayerType.COMPUTER, PlayerAlliance.BLACK);
        GameBoard = new Board();
        undoStack = new Undo();
        IsGameOver = false;
        WinnerText.GetComponent<TextMeshProUGUI>().text = "";
        RenderingDone = false;
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            Difficulty = (int)PlayerPrefs.GetFloat("Difficulty");
        }
        else
        {
            Difficulty = 1;
        }
        MinMaxAI = new MinMax(2*Difficulty);
        UpdateUIElements();
    }

    
    /// <summary>
    /// Update function
    /// </summary>
    void Update()
    {
        if(currentPlayer != null && currentPlayer.Type == PlayerType.COMPUTER && !IsGameOver && RenderingDone)
        {
            DeactivateUndoButton();
            MakeMove(-1, PlayerType.COMPUTER);
            
        }
        else if(!IsGameOver && currentPlayer != null && currentPlayer.Type == PlayerType.HUMAN)
        {
            ActivateUndoButton();
        }
    }

    /// <summary>
    /// Function to get the current player
    /// </summary>
    /// <returns></returns>
    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    #region Properties
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }

    public Board GameBoard { get; set; }
    #endregion

    /// <summary>
    /// Function to make a move
    /// </summary>
    /// <param name="column">column to put a piece on</param>
    public void MakeMove(int column, PlayerType plType)
    {
        if (IsGameOver)
        {
            Debug.Log("GameOver");
            return;
        }
        if(plType != currentPlayer.Type)
        {
            Debug.Log("Not your turn!");
            return;
        }
        //mark rendering as false
        RenderingDone = false;
        try
        {   
            if(plType == PlayerType.COMPUTER)
            {
                column = MinMaxAI.GetBestMove(currentPlayer, GameBoard);
            }
            Board GameBoardCpy = new Board(GameBoard.Table);
            GameBoard.SetPiece(column, currentPlayer.Alliance);
            undoStack.AddMementoToStack(new Memento(currentPlayer, GameBoardCpy, RenderPiece(column)));
            if (GameOver())
            {
                IsGameOver = true;
                HandleEndGame();
            }
            if (currentPlayer == Player1)
            {
                currentPlayer = Player2;
            }
            else
            {
                currentPlayer = Player1;
            }
        }
        catch (ColumnOccupiedException exc)
        {
            RenderingDone = true;

            Debug.LogError(exc.Message);
        }
        catch (InvalidColumnException exc)
        {
            RenderingDone = true;

            Debug.LogError(exc.Message);
        }
        UpdateUIElements();
        RenderingDone = true;
    }

    /// <summary>
    /// Function to render a pice on a column
    /// </summary>
    /// <param name="column"></param>
    private GameObject RenderPiece(int column)
    {
        int row = -1;
        for(int i = 0; i<BoardUtils.NUM_ROWS; i++)
        {
            if(GameBoard.Table[i, column] != Tile.EMPTY)
            {
                row = i;
                break;
            }
        }
        float xCoordinate = xCoordinates[column];
        float yCoordinate = yCoordinates[BoardUtils.NUM_ROWS - row - 1];
        GameObject prefab = currentPlayer.Alliance == PlayerAlliance.BLACK ? BlackPiecePrefab : RedPiecePrefab;
        GameObject piece = Instantiate(prefab) as GameObject;
        piece.transform.position = new Vector3(xCoordinate, pieceStartingY, -Camera.main.transform.position.z);
        piece.GetComponent<Piece>().xDest = xCoordinate;
        piece.GetComponent<Piece>().yDest = yCoordinate;
        return piece;
    }


    /// <summary>
    /// Function to undo an action form a memento
    /// </summary>
    public void ReverseFromMemento(Memento memento)
    {

        GameBoard = memento.Board;
        
        currentPlayer = memento.CurrentPlayer;
        Destroy(memento.Piece);
    }

    /// <summary>
    /// Function to check if the game is over
    /// </summary>
    /// <returns></returns>
    public bool GameOver()
    {
        return Connect4Utils.Finished(GameBoard);
    }

    /// <summary>
    /// Function to make the Undo Button inavtive while current turn is computer
    /// </summary>
    public void DeactivateUndoButton()
    {
        GameObject btn = GameObject.Find("UndoButton");
        
        if (btn != null)
        {
            
            Button undoButton = btn.GetComponent<Button>();
            if (undoButton != null)
            {
               
                undoButton.enabled = false;
            }
        }
    }

    /// <summary>
    /// Function to activate Undo Button when human player tunr is on
    /// </summary>
    public void ActivateUndoButton()
    {
        GameObject btn = GameObject.Find("UndoButton");
        if(btn != null)
        {
            Button undoButton = btn.GetComponent<Button>();
            if (undoButton != null)
            {
                undoButton.enabled = true;
            }
        }
       
    }

    /// <summary>
    /// Function to expose the undo Stack to other scripts
    /// </summary>
    public Undo GetUndoStack()
    {
        return undoStack;
    }

    /// <summary>
    /// Function to Update UI Elements
    /// </summary>
    private void UpdateUIElements()
    {
        var textMesh = GameObject.FindGameObjectWithTag("PlayerTextMesh");
        if (textMesh != null) {
            var playerText = textMesh.GetComponent<TextMeshProUGUI>();
            if (playerText != null)
            {
                playerText.text = currentPlayer.Type == PlayerType.COMPUTER ? "Computer" : "Human";

                var pieceColor = GameObject.FindGameObjectWithTag("PieceColor").GetComponent<Image>();
                pieceColor.sprite = currentPlayer.Alliance == PlayerAlliance.BLACK ? BlackPiecePrefab.GetComponent<SpriteRenderer>().sprite : RedPiecePrefab.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    /// <summary>
    /// Function to handle the end of the game
    /// </summary>
    private void HandleEndGame()
    {

        //Deactivate undo button
        DeactivateUndoButton();

        //Set Winner text
        WinnerText.GetComponent<TextMeshProUGUI>().text = currentPlayer.Type == PlayerType.COMPUTER ? "COMPUTER WON" : "HUMAN WON";

        EndGameCoordintaes coordinates = Connect4Utils.GetEndGameCoordinates(GameBoard);

        float xCoordinatePiece1 = xCoordinates[coordinates.GetStartX()];
        float yCoordinatePiece1 = yCoordinates[BoardUtils.NUM_ROWS  - coordinates.GetStartY() - 1];
        float xCoordinatePiece2 = xCoordinates[coordinates.GetStopX()];
        float yCoordinatePiece2 = yCoordinates[BoardUtils.NUM_ROWS - coordinates.GetStopY() - 1];
        Vector3 startVector = new Vector3(xCoordinatePiece1, yCoordinatePiece1, -Camera.main.transform.position.z - 1);
        Vector3 stopVector = new Vector3(xCoordinatePiece2, yCoordinatePiece2, -Camera.main.transform.position.z - 1);
  
        LineRenderer line =  gameObject.AddComponent<LineRenderer>();
        line.startWidth = lineSize;
        line.endWidth = lineSize;
        line.positionCount = 2;
        line.SetPosition(0, startVector);
        line.SetPosition(1, stopVector);
        line.material = LineMaterial;
    }


    
}
