using System.Collections;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //Vida
    public float life;
    private LifeBar lifeSlider;

    public bool vulnerable = true;

    private GameManager gameManager;
    private PlayerWeaponBar weaponBar;


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
        if (Input.GetKeyDown(KeyCode.E) && life < 100 && gameManager.medicalKit>0)
        {
            GetHealed(10);
            weaponBar.ConsumeMedicalKit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") &&vulnerable)
        {
            //PROVISIONAL CODE, TODO: QUIT LIFE BASED ON ENEMY
            GetHurt(10);
        }
    }

    public void GetHurt(long lifeLost)
    {
        vulnerable = false;

        life -= lifeLost;
        lifeSlider.SetSliderPosition(life);

        StartCoroutine(VulnerableCorutine());
    }

    public void GetHealed(long lifeHealed)
    {
        lifeSlider.Heal(lifeHealed);
    }


    IEnumerator VulnerableCorutine()
    {
        yield return new WaitForSeconds(2);
        vulnerable = true;
    }
}
