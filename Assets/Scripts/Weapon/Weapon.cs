using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon
{
    public string name;
    public GameObject gun;
    public bool isPurchased;
    public int ammunition;
    public int price;
    public Sprite weaponSprite;

    public Weapon(GameObject gun, bool isPurchased, int ammunition, int price, Sprite weaponSprite,string name)
    {
        this.gun = gun;
        this.isPurchased = isPurchased;
        this.ammunition = ammunition;
        this.price = price;
        this.weaponSprite = weaponSprite;
        this.name = name;
    }

    
}
