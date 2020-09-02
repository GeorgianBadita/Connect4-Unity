using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour
{
    /// <summary>
    /// Function to back button clicked
    /// </summary>
   public void OnBackButtonClicked()
   {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex - 1);
   }

    /// <summary>
    /// Function to handle undo button clicked
    /// </summary>
    public void OnUndoButtonClicked()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameManager gm = camera.GetComponent<GameManager>();
        Undo undoStack = gm.GetUndoStack();
        if (undoStack.Size() > 1)
        {
            gm.ReverseFromMemento(undoStack.GetLastGameState());
            gm.ReverseFromMemento(undoStack.GetLastGameState());
        }
        else
        {
            //TODO should display some error here
        }
    }

    /// <summary>
    /// Function to reload the game scene
    /// </summary>
    public void PlayAgainPressed()
    {
        Debug.Log("PRESSED AGAIN!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
