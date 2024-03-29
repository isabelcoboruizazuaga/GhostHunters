using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    //Vida
    public float life;
    private LifeBar lifeSlider;

    public bool vulnerable = true;

    private GameManager gameManager;
    private PlayerWeaponBar weaponBar;

    public AudioSource hurtSound;


    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        lifeSlider = FindObjectOfType<LifeBar>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        weaponBar = GameObject.Find("Player").GetComponent<PlayerWeaponBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && life < 100 && gameManager.medicalKit > 0 && !GameManager.isPaused)
        {
            GetHealed(10);
            weaponBar.ConsumeMedicalKit();
        }


        if (Input.GetKeyDown(KeyCode.Escape)&& !GameManager.isBuying)
        {
            if (!GameManager.isPaused) { PauseGame.Pause(); }else { PauseGame.UnPause(); }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && vulnerable)
        {
            //PROVISIONAL CODE, TODO: QUIT LIFE BASED ON ENEMY
            hurtSound.Play();
            GetHurt(10);

        }
    }

    public void GetHurt(long lifeLost)
    {
        vulnerable = false;

        life -= lifeLost;
        lifeSlider.SetSliderPosition(life);

        if (life > 0)
        {
            StartCoroutine(VulnerableCorutine());
        }
        else
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void GetHealed(long lifeHealed)
    {
        lifeSlider.Heal(lifeHealed);
    }


    IEnumerator VulnerableCorutine()
    {
        //TO DO: SHOW PLAYER IS INVULNERABLE
        yield return new WaitForSeconds(1);
        vulnerable = true;
    }
}
