using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BeeBomb : MonoBehaviour
{
    public GameObject spawnPointGO;
    private Transform spawnPoint;
    public GameObject beeModel;

    public int amount = 3;
    public float dps = 2.5f;
    public float range = 5f;
    public bool used = false;
    void Start()
    {
        spawnPoint = spawnPointGO.transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && used == false)
            spawnBees();
    }
    private void spawnBees()
    {
        used = true;
        for (int i = 0; i < amount; i++)
        {
            Destroy(Instantiate(beeModel, randomPosWithinRange(spawnPoint.position), Quaternion.identity),10f);
        }
    }
    private Vector3 randomPosWithinRange(Vector3 vector)
    {
        return new Vector3(vector.x + Random.Range(-range, range), vector.y + Random.Range(-range, range), vector.z + Random.Range(-range, range));
    }
}
