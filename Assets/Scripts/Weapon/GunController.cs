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

    private void Awake()
    {
        shotAudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //textAmmo.text = GameManager.instance.gunAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (GameManager.instance.muerto)
        {
            return;
        }*/

        if (Input.GetButtonDown("Fire1"))
        {
           /* if (GameManager.instance.tipoDeArma == 1 && GameManager.instance.gunAmmo < 1)
            {
                return;
            }
            if (GameManager.instance.tipoDeArma == 2 && GameManager.instance.grenades < 1)
            {
                return;
            }*/

            if (Time.time > shotRateTime)
            {
                //CambiarCanvas();

                //Esto creo que no es necesario, comprobar luego
                /*GameManager.instance.gunAmmo--;
                textAmmo.text =GameManager.instance.gunAmmo.ToString();*/

                shotAudioSource.PlayOneShot(shotSound);
                GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 3);
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
