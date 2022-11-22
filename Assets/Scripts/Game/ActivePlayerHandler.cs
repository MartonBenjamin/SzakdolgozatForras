using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActivePlayerHandler
{
    static List<Player> players = new List<Player>();
    public static Player ActivePlayer = null;
    public static string PlayableTag = "playable";
    public static bool hasToEnd = false;

    /// <summary>
    /// Register a player into all player list
    /// </summary>
    /// <param name="player"></param>
    public static void AddPlayer(Player player)
    {
        players.Add(player);
        if (ActivePlayer == null)
        {
            ActivePlayer = player;
            Debug.Log("Active player set to:" + player.name);
        }
        if(players.Count > 0)
        {
            hasToEnd = false;
        }
        Debug.Log("Player added: " + player.name);
    }

    /// <summary>
    /// Find all playable characters and add to playable list
    /// </summary>
    public static void FillPlayerListWithAllPlayableCharacters()
    {
        GameObject[] playableObjects = GameObject.FindGameObjectsWithTag(PlayableTag);
        foreach (GameObject go in playableObjects)
        {
            if(go.GetComponent<Player>() != null)
            {
                players.Add(go.GetComponent<Player>());
            }
        }
        Debug.Log(players.Count + " playeble character found");
        SetActivePlayer(players[0]);
        Debug.Log("Selected player: " + ActivePlayer.name);
    }

    /// <summary>
    /// Remove a player from all player list
    /// </summary>
    /// <param name="player"></param>
    public static void RemovePlayer(Player player)
    {
        players.Remove(player);
        if(players.Count <= 1)
        {
            hasToEnd = true;
            ActivePlayer.deactivatePlayer();
        }
        Debug.Log("Player added: " + player.name);
    }
    /// <summary>
    /// Set active player to player
    /// </summary>
    /// <param name="player"></param>
    public static void SetActivePlayer(Player player)
    {
        if (ActivePlayer != null) ActivePlayer.deactivatePlayer();
        ActivePlayer = player;
        ActivePlayer.activatePlayer();
    }
    private static int GetCurrentIndex()
    {
        return players.IndexOf(ActivePlayer);
    }

    /// <summary>
    /// Give the control to the next player
    /// </summary>
    public static void NextPlayer()
    {
        Debug.Log("Players list count:" + players.Count);
        Debug.Log("CurrentIndex:" + GetCurrentIndex());
        if(players.Count < 2)
        {
            hasToEnd = true;
            return;
        }
        if (GetCurrentIndex() == players.Count - 1) SetActivePlayer(players[0]);
        else SetActivePlayer(players[GetCurrentIndex() + 1]);
        Debug.Log("NewCurrentIndex:" + GetCurrentIndex());
    }
}
