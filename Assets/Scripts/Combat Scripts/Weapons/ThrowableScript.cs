using Assets.Scripts.Combat_Scripts.Weapons;
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowableScript : MonoBehaviour
{
    [SerializeField]
    private GameObject model;
    [SerializeField]
    private FollowCamera bombCam;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private Image powerIndicator;
    [SerializeField]
    private Granade granade;
    [SerializeField]
    private PlanetGravity planetGravity;
    private PlayerStats playerstat;
    private PlayerMovement playermovement;
    private Player player;
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform spawnPoint;
    [Header("Display Controls")]
    [SerializeField]
    [Range(10, 100)]
    private int linePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float timeBetweenPoints = 0.5f;

    [Header("Force settings")]
    [SerializeField]
    [Range(1, 100)]
    private float minForce = 10f;
    [SerializeField]
    [Range(10, 100)]
    private float maxForce = 50f;
    [SerializeField]
    [Range(10, 100)]
    private float force = 10f;
    void Start()
    {
        validateForceSettings();
        player = GetComponentInParent<Player>();
        playermovement = GetComponentInParent<PlayerMovement>();
        model = granade.prefab;
    }

    private void validateForceSettings()
    {
        if (minForce > maxForce)
        {
            float temp = minForce;
            minForce = maxForce;
            maxForce = temp;
        }
        if (force < minForce)
            force = minForce;
        if (force > maxForce)
            force = maxForce;
    }

    void Update()
    {
        if (playermovement.IsActive)
        {
            if (Input.GetMouseButton(0))
            {
                if (force < maxForce)
                    force += (maxForce/minForce) * Time.deltaTime;
                DrawProjection();
                Aim();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                Throw();
                force = minForce;
                timer.Pause();
                player.deactivatePlayer();
                Invoke("NextRound", 10f);
                lineRenderer.enabled = false;
            }
            updateSlider();
        }
    }

    private void Aim()
    {
        float mouseY = Input.GetAxis("Mouse Y") * 100 * Time.deltaTime;
        spawnPoint.Rotate(Vector3.left * mouseY);
    }

    private void DrawProjection()
    {
        lineRenderer.enabled = true;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        Gradient lineGradient = new Gradient();
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 0.01f) },
            new GradientAlphaKey[] { new GradientAlphaKey(.8f, 0.0f), new GradientAlphaKey(0f, 0.01f) }
        );
        lineRenderer.colorGradient = gradient;
        lineRenderer.positionCount = Mathf.CeilToInt(linePoints / timeBetweenPoints) + 1;
        Vector3 startPosition = spawnPoint.position;
        Vector3 startVelocity = force * spawnPoint.forward / granade.prefab.GetComponent<Rigidbody>().mass;
        int i = 0;
        lineRenderer.SetPosition(i, startPosition);
        for (float time = 0; time < linePoints; time += timeBetweenPoints)
        {
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (planetGravity.GravityVector.y / 2f * time * time);
            i++;
            lineRenderer.SetPosition(i, point);
        }
    }

    private void NextRound()
    {
        timer.NextRound();
    }
    private void Throw()
    {
        GameObject throwable = Instantiate(model, spawnPoint.position, spawnPoint.rotation);
        throwable.GetComponent<Rigidbody>().AddForce(calculateForce(), ForceMode.Impulse); //Throws the instance
    }
    private Vector3 calculateForce()
    {
        return spawnPoint.forward * force;
    }
    private void followCamera(GameObject obj)
    {
        bombCam.target = obj;
    }
    private void updateSlider()
    {
        if (powerIndicator != null)
        {
            powerIndicator.fillAmount = force / maxForce;
        }
    }
}
