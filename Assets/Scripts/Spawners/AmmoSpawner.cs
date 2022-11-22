using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    private float timer;
    public float spawnTimer = 10.0f;
    public Vector3 point1;
    public Vector3 point2;
    public GameObject ammo;
    public int amount = 1;
    [SerializeField]
    private bool autoDestroy = false;
    [SerializeField]
    private float autoDestroyTime = 10f;
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > spawnTimer)
        {
            SpawnAmmo();
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }
    /// <summary>
    /// Spawns ammo between point1 and point2;
    /// </summary>
    private void SpawnAmmo()
    {
        float randX;
        float randY;
        float randZ;
        GameObject ammoSpawn = null;

        for (int i = 0; i <= amount; i++)
        {
            randX = Random.Range(point1.x, point2.x);
            randY = Random.Range(point1.y, point2.y);
            randZ = Random.Range(point1.z, point2.z);
            ammoSpawn = Instantiate(ammo, new Vector3(randX, randY, randZ), ammo.transform.rotation) as GameObject;
            if (autoDestroy)
            {
                Destroy(ammoSpawn, autoDestroyTime);
            }
        }

        if (ammoSpawn != null)
            Destroy(ammoSpawn, 60.0f);
    }

}
