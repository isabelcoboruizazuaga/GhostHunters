using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyableItemController : MonoBehaviour
{
    private Image image;
    private Image selectedImage;

    // Start is called before the first frame update
    void Start()
    {
        selectedImage= GameObject.Find("ImageSelected").GetComponent<Image>();
        image= this.GetComponent<Image>();
    }

    public void ObjectClicked()
    {
        selectedImage.GetComponent<Image>().sprite = image.sprite;
    }

}
