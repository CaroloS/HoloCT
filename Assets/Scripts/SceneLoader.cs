using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Networking;

public class SceneLoader : MonoBehaviour
{

    GameObject object2;
    [SerializeField]
    public Text text;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetText());

    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://holoctazureblobs.blob.core.windows.net/blob/new.xml");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;

            XDocument xmldoc2 = new XDocument();
            xmldoc2 = XDocument.Parse(www.downloadHandler.text);
            string value = xmldoc2.Element("patient").Element("patientCase").Element("lastEditedBy").Value;
            text.text = value;

        }
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

    public void load_Static_Scene()
    {
        SceneManager.LoadScene("Origami");
    }

    public void load_Dynamic_Scene()
    {
        SceneManager.LoadScene("ListScene");
    }


    void Update()
    {

    }
}
