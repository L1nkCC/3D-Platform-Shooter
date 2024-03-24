using JUTPS.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class InfiniteAmmoWReload : MonoBehaviour
{
    Weapon weapon;
    void Start()
    {
        weapon = GetComponent<Weapon>();
    }
    private void Update()
    {
        weapon.TotalBullets = 9999;
    }

}
