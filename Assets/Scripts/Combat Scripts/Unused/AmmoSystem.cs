using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    [SerializeField] private GameObject bulletBar;
    public int maxAmmo = 15;
    public int currentAmmo;

    public int magazineSize = 5;
    public int currentMagazine;

    public Text AmmoText;
    public bool noAmmo = false;
    private void Start()
    {
        currentAmmo = maxAmmo;
        SetAmmoBox();
        bulletBar.SetActive(true);
        currentMagazine = magazineSize;
    }
    public void ShootAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            SetAmmoBox();
        }
        else
        {
            noAmmo = true;
        }
    }
    void SetAmmoBox()
    {
        AmmoText.text = currentAmmo + "/" + maxAmmo;
    }
    public void AmmoPickUp(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > maxAmmo)
            currentAmmo = maxAmmo;
        noAmmo = false;
        SetAmmoBox();
    }
}
