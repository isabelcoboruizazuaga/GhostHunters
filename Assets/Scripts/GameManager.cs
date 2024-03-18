using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite oldGun, gun, powerGun, semiAutomaticGun;
    public Sprite oldGunBullet, gunBullet, powerGunBullet, semiAutomaticGunBullet;
    public WeaponList weaponList = new WeaponList();
    public BulletList bulletList = new BulletList();

    void Awake()
    {
        weaponList = new WeaponList();
        bulletList = new BulletList();
        CreateBullets();
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
        weaponGo.SetActive(false);

        weaponGo = GameObject.Find("PowerGun");
        weaponList.AddWeapon(weaponGo,false,10,50,powerGun, "PowerGun");
        weaponGo.SetActive(false);

        weaponGo = GameObject.Find("SemiAutomaticGun");
        weaponList.AddWeapon(weaponGo, false, 50, 100, semiAutomaticGun, "SemiAutomaticGun");
        weaponGo.SetActive(false);

    }

    private void CreateBullets()
    {
        GameObject weaponGo = GameObject.Find("OldGun");
        bulletList.AddBullet(weaponGo, -1, 0, oldGunBullet, "oldGunBullet");

        weaponGo = GameObject.Find("Gun");
        bulletList.AddBullet(weaponGo, 10, 2, gunBullet, "gunBullet");


        weaponGo = GameObject.Find("PowerGun");
        bulletList.AddBullet(weaponGo, 10, 3, powerGunBullet, "powerGunBullet");


        weaponGo = GameObject.Find("SemiAutomaticGun");
        bulletList.AddBullet(weaponGo, 100, 5, semiAutomaticGunBullet, "semiAutomaticGunBullet");
    }

}
