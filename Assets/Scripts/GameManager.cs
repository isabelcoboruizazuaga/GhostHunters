using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite oldGun, gun, powerGun, semiAutomaticGun;
    public WeaponList weaponList = new WeaponList();

    void Awake()
    {
        weaponList = new WeaponList();
        CreateWeapons();
    }

    private void Start()
    {
        
    }

    private void CreateWeapons()
    { 
        GameObject weaponGo = GameObject.Find("OldGun");
        weaponList.AddWeapon(weaponGo,true,-1,0,oldGun, "OldGun");
        weaponGo.SetActive(true);

        weaponGo = GameObject.Find("Gun");
        weaponList.AddWeapon(weaponGo, false, 10, 20, gun,"Gun");
        weaponGo.SetActive(true);

        weaponGo = GameObject.Find("PowerGun");
        weaponList.AddWeapon(weaponGo,false,10,50,powerGun, "PowerGun");
        weaponGo.SetActive(true);

        weaponGo = GameObject.Find("SemiAutomaticGun");
        weaponList.AddWeapon(weaponGo, false, 50, 100, semiAutomaticGun, "SemiAutomaticGun");
        weaponGo.SetActive(true);

    }

}
