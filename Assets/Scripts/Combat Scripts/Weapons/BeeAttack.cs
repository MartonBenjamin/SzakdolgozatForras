using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public GameObject closestCharacter;
    public float rotationSpeed = 3.5f;
    public float movementSpeed = 2f;
    public float dps = 2f;
    void Start()
    {
        closestCharacter = FindClosestCharacter();
    }

    private GameObject FindClosestCharacter()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("playable");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    void Update()
    {
        Attack();
    }
    private void LookToClosestCharacter()
    {
        if (closestCharacter != null)
        {
            Vector3 targetDirection = closestCharacter.transform.position - transform.position;
            float step = rotationSpeed * Time.deltaTime;
            Vector3 lookDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            Debug.DrawRay(transform.position, lookDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
    private void MoveToClosestCharacter()
    {
        if(closestCharacter != null)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, closestCharacter.transform.position, step);
        }
    }
    private void DealDamage()
    {
        BeeBomb script = GetComponentInParent<BeeBomb>();

        PlayerStats stats = closestCharacter.GetComponent<PlayerStats>();

        if (Vector3.Distance(transform.position, closestCharacter.transform.position) < 2f)
        {
            stats.CurrentHealth -= dps;
            Destroy(this.gameObject);
        }

    }
    private void Attack()
    {
        if (closestCharacter != null)
        {
            LookToClosestCharacter();
            MoveToClosestCharacter();
            DealDamage();
        }
    }
}
