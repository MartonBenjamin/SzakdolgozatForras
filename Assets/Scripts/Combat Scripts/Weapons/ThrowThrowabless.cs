using Assets.Scripts.Combat_Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowThrowables : MonoBehaviour
{
    public Transform spawnPoint;
    public Granade granade;
    public GameObject model;
    public GameObject predictObject;
    public FollowCamera bombCam;
    public Timer timer;
    public Image powerIndicator;

    private PlayerStats playerstat;
    private PlayerMovement playermovement;

    private float maxForce = 30f;
    [SerializeField]
    private float minForce = 10f;
    [SerializeField]
    float force = 10f;
    // Update is called once per frame
    void Start()
    {
        playermovement = GetComponentInParent<PlayerMovement>();
        model = granade.prefab;
    }
    void Update()
    {
        if (this.GetComponentInParent<PlayerMovement>().IsActive)
        {
            if (Input.GetMouseButton(0))
            {
                if (force < maxForce)
                    force += 0.1f;
            }
            updateSlider();
            if (Input.GetButtonUp("Fire1"))
            {
                Throw();
                force = minForce;
                Invoke("NextRound", 11f);
            }
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
        followCamera(throwable);
        //playermovement.isActive = false;
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
