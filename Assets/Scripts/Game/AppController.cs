using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{
    private bool isPaused;
    [SerializeField]
    private GameObject congratImage;
    public bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; }
    }

    private void Start()
    {
        CinemachineVirtualCamera[] cinemachineVirtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        Debug.Log("AllCameras" + cinemachineVirtualCameras.Length);
        //CinemachineCameraHandler.AddCamera(cinemachineVirtualCameras.Where(c => c.tag.Equals("ThrowableCamera")).First());
        ActivePlayerHandler.FillPlayerListWithAllPlayableCharacters();
        congratImage.SetActive(false);
    }

    void Update()
    {
        checkInput();
        checkIfEnded();
    }

    private void checkIfEnded()
    {
        if (ActivePlayerHandler.hasToEnd)
        {
            Debug.Log("Game ended");
            congratImage.SetActive(true);
            Invoke("GoToMenu", 5);
        }
    }

    private void GoToMenu()
    {
        congratImage.SetActive(false);
        ActivePlayerHandler.hasToEnd = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        Cursor.lockState = CursorLockMode.None;
    }

    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) GoToMenu();
        if (Input.GetKeyDown(KeyCode.P)) PauseOrResumeGame();
        //if (Input.GetKeyDown(KeyCode.K)) ActivePlayerHandler.NextPlayer();
    }

    private void PauseOrResumeGame()
    {
        if (IsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        Debug.Log("Game paused");
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Game resumed");
    }
}
