using TMPro;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform spawnPoint; //punto de salida de la bala
    public GameObject bullet;

    public float shotForce = 10000; //velocidad con la que sale la bala
    public float shotRate = 0.5f; //Tiempo hasta el proximo disparo
    private float shotRateTime = 0;

    public AudioClip shotSound;
    private AudioSource shotAudioSource;

    public TextMeshProUGUI textAmmo;
    public TextMeshProUGUI textGrenades;

    public bool automatic = false;
    private GameManager gameManager;

    //Bullet control
    private PlayerWeaponBar playerWeaponBar;
    private object[] activeWeaponObject;

    private void Awake()
    {
        shotAudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerWeaponBar = GameObject.Find("Player").GetComponent<PlayerWeaponBar>();
       // activeWeaponObject = playerWeaponBar.activeWeaponObjectComplete;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (GameManager.instance.muerto)
         {
             return;
         }*/
        if (!automatic)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                int bullets = playerWeaponBar.activeWeapon.ammunition;

                if (Time.time > shotRateTime && (bullets>0 || bullets==-1))
                {
                    //Update bullets in canvas and WeaponBar
                    if (bullets != -1) //Si no tiene balas infinitas
                    {
                        //update bullet in list 
                        bullets--;
                        playerWeaponBar.activeWeapon.ammunition = bullets;
                        gameManager.weaponList.UpdateWeapon(playerWeaponBar.activeWeapon);

                        playerWeaponBar.UpdateBullets(bullets.ToString(),activeWeaponObject);
                    }
                    else
                    {
                        playerWeaponBar.UpdateBullets("\u221E", activeWeaponObject);
                    }
                    //CambiarCanvas();

                    //Esto creo que no es necesario, comprobar luego
                    /*GameManager.instance.gunAmmo--;
                    textAmmo.text =GameManager.instance.gunAmmo.ToString();*/

                    // shotAudioSource.PlayOneShot(shotSound);

                    GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

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

                    playerWeaponBar.UpdateBullets(bullets.ToString(), activeWeaponObject);

                    GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                    newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shotForce);
                    Destroy(newBullet, 3);

                    shotRateTime = Time.time + shotRate;
                }
            }
        }
    }
    /*
    private void CambiarCanvas()
    {
        switch (GameManager.instance.tipoDeArma)
        {
            case 1:
                GameManager.instance.gunAmmo--;
                textAmmo.text = GameManager.instance.gunAmmo.ToString();
                break;
            case 2:
                GameManager.instance.grenades--;
                textGrenades.text = GameManager.instance.grenades.ToString();
                break;
        }
    }*/
}
