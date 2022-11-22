using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Jetpack : MonoBehaviour
{
    private float maxFuel = 100;
    [SerializeField]
    private float power = 100;
    private float currentFuel;
    [SerializeField]
    private ParticleSystem particles;
    public TMP_Text JetPackGUI;
    private bool isEmpty;
    private PlayerStats playerStats;

    public bool IsEmpty
    {
        get { return isEmpty; }
        set { isEmpty = value; }
    }

    private void Start()
    {
        currentFuel = maxFuel;
        particles = GetComponentInChildren<ParticleSystem>();
        UpdateText();
        particles.enableEmission = false;
        playerStats = GetComponentInParent<PlayerStats>();
        IsEmpty = false;
    }


    void Update()
    {
        if (playerStats.IsCurrentActive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jetpacking();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                particles.enableEmission = false;
            }
            if (currentFuel < maxFuel && !particles.emission.enabled)
            {
                currentFuel += Time.deltaTime / 2;
                IsEmpty = false;
            }
            UpdateText();
        }

    }
    private void Jetpacking()
    {
        if (currentFuel <= 0.1)
            IsEmpty = true;
        if (!IsEmpty)
        {
            PlayerMovement playerController = GetComponentInParent<PlayerMovement>();
            particles.enableEmission = true;
            currentFuel -= 10 * Time.deltaTime;
            float ascendingPower = power;
            playerController.Ascend(ascendingPower);
        }     
    }
    private void UpdateText()
    {
        JetPackGUI.text = ("Fuel: "+(int)currentFuel).ToString();
    }
}
