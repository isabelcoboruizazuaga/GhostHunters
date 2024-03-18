using System.Collections.Generic;
using UnityEngine;

public class WeaponList
{
    public List<Weapon> weapons;

    public WeaponList()
    {
        this.weapons = new List<Weapon>();
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }
    public void AddWeapon(GameObject gun, bool isPurchased, int ammunition, int price, Sprite weaponSprite, string name)
    {
        Weapon weapon = new Weapon(gun, isPurchased, ammunition, price, weaponSprite, name);
        weapons.Add(weapon);
    }

    public void RemoveWeapon(Weapon weapon)
    {
        weapons.Remove(weapon);
    }
    public Weapon FindWeaponBySprite(Sprite sprite)
    {
        foreach (var weapon in weapons)
        {
            if (weapon.weaponSprite.name.Equals(sprite.name))
            {
                return weapon;
            }
        }
        return null;
    }
    public void SetWeaponPurchased(Weapon weapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            var wpn = weapons[i];
            //Finds whe weapon to change
            if (wpn.name.Equals(weapon.name))
            {
                weapon.isPurchased = true;
                //Updates it in the list
                weapons[i] = weapon;
            }
        }
    }
    public void UpdateWeapon(Weapon weapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            var wpn = weapons[i];
            //Finds whe weapon to change
            if (wpn.name.Equals(weapon.name))
            {
                //Updates it in the list
                weapons[i] = weapon;
            }
        }
    }
    public Weapon GetWeaponByIndex(int index)
    {
        return weapons[index];
    }

    public void SetOneWeaponActive(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i != index)
            {
                weapons[i].gun.SetActive(false);
            }
            else
            {
                weapons[i].gun.SetActive(true);
            }
        }
    }

}
