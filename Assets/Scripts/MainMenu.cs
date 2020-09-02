using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Slider slider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Difficulty"))
        {
            PlayerPrefs.SetFloat("Difficulty", 1);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void DifficultyChanged(float newDifficulty)
    {
        PlayerPrefs.SetFloat("Difficulty", newDifficulty);
    }

    public void SetSliderValue()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            slider.value = PlayerPrefs.GetFloat("Difficulty");
        }
        else
        {
            slider.value = 1;
            PlayerPrefs.SetFloat("Difficulty", 1);
        }
    }
}
