using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    [SerializeField]
    float roundTime = 30f;
    private float actualtime;
    public static List<string> teamTags = new List<string>();
    private string activeTeam;
    private int activeTeamIndex = 0;
    private bool isPaused = false;

    public void Start()
    {
        Invoke("StartGame", 2f);
    }
    public string ActiveTeam
    {
        get { return activeTeam; }
        set { activeTeam = value; }
    }
    private void StartGame()
    {
        actualtime = roundTime;
        //ActivePlayerHandler.NextPlayer();
    }

    void Update()
    {
        CountDown();
    }
    public void Pause()
    {
        isPaused = true;
    }
    private void CountDown()
    {
        if (!isPaused)
        {
            actualtime -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(actualtime);
        }
        if (actualtime <= 0)
        {
            NextRound();
        }
    }
    public void NextRound()
    {
        ActivePlayerHandler.NextPlayer();
        ResetRoundTime();
    }
    private void ResetRoundTime()
    {
        isPaused = false;
        actualtime = roundTime;
    }
}
