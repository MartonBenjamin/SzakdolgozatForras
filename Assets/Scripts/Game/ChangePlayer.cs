using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    public static List<GameObject> team;
    private GameObject selectedPlayer;
    string tag = "playerTeam";
    int index = 0;
    public GameObject CongratImage;
    public FollowCamera camera;
    void Start()
    {
        team = new List<GameObject>(GameObject.FindGameObjectsWithTag(tag));
        selectedPlayer = team[index];
        disableMovementScripts();
        CongratImage.active = false;
        camera.target = selectedPlayer;
        camera.setTarget();
        selectedPlayer.GetComponent<PlayerMovement>().IsActive = true;
    }
    private void disableMovementScripts()
    {
        for (int i = 0; i < team.Count; i++)
        {
            team[i].GetComponent<PlayerMovement>().IsActive = false;
        }
    }
   

    public void nextPlayer()
    {
        if(team.Count == 1)
        {
            CongratImage.active = true;
            Invoke("LoadNextScene", 5f);
        }
        selectedPlayer.GetComponent<PlayerMovement>().IsActive = false;
        if (++index > team.Count - 1)
            index = 0;
        selectedPlayer = team[index];
        if (selectedPlayer != null)
        {
            camera.target = selectedPlayer;
            camera.setTarget();
            selectedPlayer.GetComponent<PlayerMovement>().IsActive = true;
            Debug.Log("Selected player:" + index);
        }
    }
    private void LoadNextScene()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
