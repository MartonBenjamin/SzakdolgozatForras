using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerStats : MonoBehaviour
{
    public GameObject[] graves;
    public Timer timer;
    private int maxHP = 100;
    private PlayerMovement movement;
    public Image healthBar;
    [SerializeField]
    private bool CurrentActive;
    private CinemachineVirtualCamera virtualCamera;

    public CinemachineVirtualCamera VirtualCamera
    {
        get { return virtualCamera; }
    }


    private void OnEnable()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        CinemachineCameraHandler.AddCamera(virtualCamera);
    }

    public bool IsCurrentActive
    {
        get { return CurrentActive; }
        set
        {
            CurrentActive = value;
        }
    }

    public int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }

    [SerializeField]
    private float currentHealth;
    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (currentHealth <= MaxHP)
                currentHealth = value;
            if (currentHealth > maxHP)
                currentHealth = maxHP;
            if (currentHealth <= 0)
                Death();
            if (healthBar != null)
                healthBar.fillAmount = CurrentHealth / maxHP;
        }
    }
    private int money;

    public int Money
    {
        get { return money; }
        set
        {
            if (value >= 0)
                money = value;
        }
    }

    public void getMoney(int amount)
    {
        if (amount > 0)
            money += amount;
    }
    public void pay(int price)
    {
        if (price <= money)
            money -= price;
    }

    private void Start()
    {
        CurrentHealth = maxHP;
        if (gameObject.tag.Equals("playerTeam"))
            healthBar.color = Color.green;
        else if (gameObject.tag.Equals("player2Team"))
            healthBar.color = Color.red;
        if (!Timer.teamTags.Contains(tag))
            Timer.teamTags.Add(tag);
        movement = GetComponent<PlayerMovement>();

    }
    public void Death()
    {
        IsCurrentActive = false;
        //timer.NextRound();
        CinemachineCameraHandler.RemoveCamera(virtualCamera);
        ActivePlayerHandler.RemovePlayer(this.GetComponent<Player>());
        Destroy(this.gameObject);
        setGrave();
    }

    private GameObject getRandomGrave()
    {
        return graves[Random.Range(0, graves.Length)];
    }
    private void setGrave()
    {
        GameObject prefab = getRandomGrave();
        prefab.AddComponent<Rigidbody>();
        GameObject grave = Instantiate(prefab, this.gameObject.transform.position + Vector3.up * 5, this.gameObject.transform.rotation);
        Destroy(grave, 5f);
    }

}
