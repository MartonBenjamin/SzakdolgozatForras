using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Combat_Scripts.Weapons
{
    [CreateAssetMenu(fileName = "New Throwable", menuName = "Items/Weapons/Throwable")]
    public class Granade : ScriptableObject
    {
        [SerializeField]
        private Sprite icon;
        [SerializeField]
        new private string name;
        [SerializeField]
        private string description;
        [SerializeField]
        public GameObject prefab;
        [SerializeField]
        public GameObject effect;
        [SerializeField]
        public float damage;
        [SerializeField]
        public float radius;
        [SerializeField]
        public float explosionForce;
        [SerializeField]
        public int delay;

    }
}
