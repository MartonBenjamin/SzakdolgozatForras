using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text TeamCountText;
    public Slider teamSlider;
    public static int playerCount = 0;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (TeamCountText != null && teamSlider != null)
        {
            TeamCountText.text = teamSlider.value.ToString();
            playerCount = (int)teamSlider.value;
        }
    }
}
