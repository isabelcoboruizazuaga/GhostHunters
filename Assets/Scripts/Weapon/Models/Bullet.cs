using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    public string name;
    public GameObject gun;
    public int quantity;
    public int price;
    public Sprite bulletSprite;

    public Bullet(GameObject gun, int quantity, int price, Sprite bulletSprite, string name)
    {
        this.gun = gun;
        this.quantity = quantity;
        this.price = price;
        this.bulletSprite = bulletSprite;
        this.name = name;
    }

}
