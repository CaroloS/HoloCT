using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class OnStart : MonoBehaviour {

    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected GameObject image;
    [SerializeField]
    protected GameObject image1;
    [SerializeField]
    protected GameObject image2;

    // Use this for initialization
    void Start () {
        Texture2D tex1 = (Texture2D)Resources.Load("brain_hist");
        ChangeImage(tex1, image1);

        Texture2D tex2 = (Texture2D)Resources.Load("lung_hist");
        ChangeImage(tex2, image2);

        Texture2D tex3 = (Texture2D)Resources.Load("brain_CT");
        ChangeImage(tex3, image);

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void ChangeImage(Texture2D texture, GameObject imageToChange)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        imageToChange.GetComponent<Image>().sprite = sprite;
    }

    private void ChangeImage(Texture texture)
    {
        ChangeImage(texture as Texture2D);
    }
}
