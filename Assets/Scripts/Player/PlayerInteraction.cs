using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //Vida
    public float life;
    private LifeBar lifeSlider;


    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        lifeSlider = FindObjectOfType<LifeBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && life < 100)
        {
            //PROVISIONAL CODE, TODO: ADD HEALING ITEM AND CHECK IF IT'S IN INVENTORY
            GetHealed(10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //PROVISIONAL CODE, TODO: QUIT LIFE BASED ON ENEMY
            GetHurt(10);
        }
    }

    public void GetHurt(long lifeLost)
    {
        //Debug.Log("vida: " + life + "vida perdida: " + lifeLost + "restante= " + (life-lifeLost));
        life -= lifeLost;
        lifeSlider.SetSliderPosition(life);
    }

    public void GetHealed(long lifeHealed)
    {
        lifeSlider.Heal(lifeHealed);
    }
}
