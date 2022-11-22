using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ItemSystem.Consumables
{
    class HealthPotion : MonoBehaviour
    {
        [SerializeField]
        private int strength = 25;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponentInParent<PlayerStats>() != null)
            {
                Destroy(this.gameObject);
                collision.gameObject.GetComponentInParent<PlayerStats>().CurrentHealth += strength;
            }
        }
       
    }
}
