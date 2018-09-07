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


    // Use this for initialization
    void Start()
    {  
        getMetaData();
        getImageAnnotations();
    }


    private void getMetaData()
    {
        List<String> metaData = XMLParser.parseMetaData();

        Dictionary<Text, string> myDict = new Dictionary<Text, string>
                {
                    { text1, metaData[0]  },
                    { text2, metaData[1] },
                    { text3, metaData[2] },
                    { text4, metaData[3] }
                };

        foreach (KeyValuePair<Text, string> entry in myDict)
        {
            entry.Key.text = entry.Value;
        }
    }

    private void getImageAnnotations()
    {
        List<Texture2D> textures = new List<Texture2D>();
        List<string> imageAnnotations = XMLParser.parseImageAnnotation();

        if (imageAnnotations.Any())
        {
         foreach (string element in imageAnnotations)
                {
                  //  Debug.Log(element);
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
                if (XMLParser.imageTags.Count() >=1)
                {
                    tag1.text = XMLParser.imageTags[0];
                }
            }
            else
            {
                ChangeImage(textures[0], image1);
                ChangeImage(textures[1], image2);
                if (XMLParser.imageTags.Count() >= 2)
                {
                    tag1.text = XMLParser.imageTags[0];
                    tag2.text = XMLParser.imageTags[1];
                }
            }
        }
        else
        {
            GameObject.Find("CanvasGroup").SetActive(false);
        }
        caseName.text = preLoadScene.blobName;
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
        XMLParser.imageTags.Clear();
        preLoadScene.meshes.Clear();
        preLoadScene.MeshCount = 0;
        SceneManager.LoadScene("ListScene");

    }

    // Update is called once per frame
    void Update()
    {

    }


}






