using TMPro;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform spawnPoint; 
    public GameObject bullet;

    public float shotForce = 10000; 
    public float shotRate = 0.5f; 
    private float shotRateTime = 0;

    public AudioClip shotSound;
    public AudioSource shotAudioSource;

    public bool automatic = false;
    private GameManager gameManager;

    //Bullet control
    private PlayerWeaponBar playerWeaponBar;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerWeaponBar = GameObject.Find("Player").GetComponent<PlayerWeaponBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!automatic)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                int bullets = playerWeaponBar.activeWeapon.ammunition;

                if (Time.time > shotRateTime && (bullets>0 || bullets==-1))
                {
                    //Update bullets in canvas and WeaponBar
                    if (bullets != -1) //When bullets are finite
                    {
                        //update bullet in list 
                        bullets--;
                        playerWeaponBar.activeWeapon.ammunition = bullets;
                        gameManager.weaponList.UpdateWeapon(playerWeaponBar.activeWeapon);

                        playerWeaponBar.UpdateBullets(bullets.ToString());
                    }
                    else
                    {
                        playerWeaponBar.UpdateBullets("\u221E");
                    }

                    GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                    shotAudioSource.PlayOneShot(shotSound);

                    newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shotForce);
                    Destroy(newBullet, 3);

                    shotRateTime = Time.time + shotRate;
                }

            }

        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                int bullets = playerWeaponBar.activeWeapon.ammunition;

                if (Time.time > shotRateTime && bullets > 0 )
                {
                    //Update bullets in canvas and WeaponBar 
                    bullets--;
                    playerWeaponBar.activeWeapon.ammunition = bullets;
                    gameManager.weaponList.UpdateWeapon(playerWeaponBar.activeWeapon);

                    playerWeaponBar.UpdateBullets(bullets.ToString());

                    GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                    shotAudioSource.PlayOneShot(shotSound);

                    newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shotForce);
                    Destroy(newBullet, 3);

                    shotRateTime = Time.time + shotRate;
                }
            }
        }
    }
}
