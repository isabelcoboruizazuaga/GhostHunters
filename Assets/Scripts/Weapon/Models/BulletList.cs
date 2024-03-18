using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletList
{
    public List<Bullet> bullets;

    public BulletList()
    {
        this.bullets = new List<Bullet>();
    }

    public void AddBullet(Bullet bullet)
    {
        bullets.Add(bullet);
    }
    public void AddBullet(GameObject gun, int quantity, int price, Sprite bulletSprite, string name)
    {
        Bullet bullet = new Bullet(gun, quantity, price, bulletSprite, name);
        bullets.Add(bullet);
    }

    public void RemoveBullet(Bullet bullet)
    {
        bullets.Remove(bullet);
    }
    public Bullet FindBulletBySprite(Sprite sprite)
    {
        foreach (var bullet in bullets)
        {
            if (bullet.bulletSprite.name.Equals(sprite.name))
            {
                return bullet;
            }
        }
        return null;
    }

    public void UpdateBullet(Bullet bullet)
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            var wpn = bullets[i];
            //Finds whe bullet to change
            if (wpn.name.Equals(bullet.name))
            {
                //Updates it in the list
                bullets[i] = bullet;
            }
        }
    }
    public Bullet GetBulletByIndex(int index)
    {
        return bullets[index];
    }
}
