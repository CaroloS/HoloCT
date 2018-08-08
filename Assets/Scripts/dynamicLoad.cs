using System.Net;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Security;
using System.Xml;

using System;
using System.Collections;
using HoloToolkit.UX.ToolTips;
using System.Text;
using Azure.StorageServices;
using UnityGLTF.Loader;
using System.IO;
using RESTClient;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class dynamicLoad : MonoBehaviour
{
    public Stream LoadedStream { get; private set; }
    
    private StorageServiceClient client;
    private BlobService blobService;

    [Header("Azure Storage Service")]
    [SerializeField]
    private string storageAccount;
    [SerializeField]
    private string accessKey;
    [SerializeField]
    private string container;

    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected Text text1;
    [SerializeField]
    protected Text text2;
    [SerializeField]
    protected Text text3;
    [SerializeField]
    protected Text text4;
    [SerializeField]
    protected Text tag1;
    [SerializeField]
    protected Text tag2;
    [SerializeField]
    protected Text caseName;

    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected GameObject image1;
    [SerializeField]
    protected GameObject image2;
  

    public static String blobName;
    public static XDocument xmldoc = new XDocument();
   // public static XDocument xmldoc2 = new XDocument();
   // public static XDocument xmldoc3 = new XDocument();

    public static int MeshCount = 0;
    public static List<string> meshes = new List<string>();

    // Use this for initialization
    void Start()
    {
        
        getMetaData();
        getImageAnnotations();

    }


    private void getMetaData()
    {
     
        foreach (XElement element in xmldoc.Descendants("patientCase"))
        {
             Dictionary<Text, string> myDict = new Dictionary<Text, string>
                {
                    { text1, element.Element("patientAge").Value  },
                    { text2, element.Element("revisionNumber").Value },
                    { text3, element.Element("lastEditedBy").Value },
                    { text4, element.Element("DateAndTimeOfLastEdit").Value }
                };

        foreach (KeyValuePair<Text, string> entry in myDict)
            {
                entry.Key.text = entry.Value;
            }
        }
           
    }


    private void getImageAnnotations()
    {
        List<string> imageAnnotations = new List<string>();
        List<Texture2D> textures = new List<Texture2D>();
        List<string> tags = new List<string>();

        var hasAnnotation = xmldoc.Descendants("annotation");

        if (hasAnnotation != null)
        {
            foreach (XElement element1 in xmldoc.Descendants("annotationData"))
            {
                string type = element1.Attribute("type").Value.ToString();
                string tag = element1.Attribute("tag").Value.ToString();

                if (type == "image")
                {
                    string CurrentValue = (string)element1;
                    imageAnnotations.Add(CurrentValue);
                    tags.Add(tag);
                }
            }
        }

        if (imageAnnotations.Any())
        {
         foreach (string element in imageAnnotations)
                {
                    Debug.Log(element);
                    byte[] imageBytes = System.Convert.FromBase64String(element);
                    Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                    tex.LoadImage(imageBytes);
                    textures.Add(tex);
                }
        }

       
        if (textures.Any())
        {
            if (textures.Count() == 1)
            {
                ChangeImage(textures[0], image1);
                if (tags.Count() >=1)
                {
                    tag1.text = tags[0];
                }
            }
            else
            {

                ChangeImage(textures[0], image1);
                ChangeImage(textures[1], image2);
                if (tags.Count() >= 2)
                {
                    tag1.text = tags[0];
                    tag2.text = tags[1];

                }
            }
        }
        else
        {
           // GameObject.Find("CanvasGroup").SetActive(false);
        }

        caseName.text = blobName;
        

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

    public void backToListscene()
    {
        meshes.Clear();
        MeshCount = 0;
        SceneManager.LoadScene("ListScene");

    }

    // Update is called once per frame
    void Update()
    {

    }

    


}



/*

     Debug.Log(node.Value);
     TextMesh text = label.GetComponent<TextMesh>();
     text.text = node.Value;


     TextMesh text2 = label2.GetComponent<TextMesh>();
     text2.text = node1.Value;


     Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
     tex.LoadImage(imageBytes);
     ChangeImage(tex, image);

     Texture2D tex1 = (Texture2D)Resources.Load("brain_hist");
     ChangeImage(tex1, image1);

     Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
     texture.LoadImage(imageBytes);
     ChangeImage(texture, image2);

   //  Texture2D tex2 = (Texture2D)Resources.Load("brain_CT");
   //  ChangeImage(tex2, image2);
   */




