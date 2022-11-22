using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerStats playerStats;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStats    = GetComponent<PlayerStats>();
        deactivatePlayer();
    }
    private void setActive(bool value)
    {
        playerMovement.IsActive = value;
        playerStats.IsCurrentActive = value;
        CinemachineCameraHandler.SwitchCamera(playerStats.VirtualCamera);
    }
    public void activatePlayer()
    {
        setActive(true);
    }
    public void deactivatePlayer()
    {
        setActive(false);
    }
}
