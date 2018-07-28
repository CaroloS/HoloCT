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

public class dynamicLoad : MonoBehaviour
{
    public Stream LoadedStream { get; private set; }

    [SerializeField]
    private BlobStorageConfig blobStorageConfig;

    [Header("Azure Storage Service")]
    [SerializeField]
    private string storageAccount;
    [SerializeField]
    private string accessKey;
    [SerializeField]
    private string container;
    [SerializeField]
    private string filename;
    [SerializeField]
    public bool Multithreaded = true;

    private StorageServiceClient client;
    private BlobService blobService;

    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected GameObject label;
    protected GameObject label1;
    protected GameObject label2;

    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected GameObject image;
    [SerializeField]
    protected GameObject image1;
    [SerializeField]
    protected GameObject image2;


    // Use this for initialization
    void Start()
    {
        

        if (string.IsNullOrEmpty(storageAccount) || string.IsNullOrEmpty(accessKey))
        {
            Debug.Log( "Storage account and access key are required - Enter storage account and access key in Unity Editor" );
        }

        client = StorageServiceClient.Create(storageAccount, accessKey);
        blobService = client.GetBlobService();

        string resourcePath = container + "/" + filename;
        StartCoroutine(blobService.GetTextBlob(GetTextBlob, resourcePath));
        
    

    }

    private void GetTextBlob(RestResponse response)
    {
        if (response.IsError)
        {
            Debug.Log( response.ErrorMessage + " Error getting blob:" + response.Content);
            return;
        }

        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Load(response.Content);
        parseXML(xmldoc);

    }

    private void parseXML(XDocument xmldoc)
    {
       

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

    // Update is called once per frame
    void Update()
    {

    }



    private void LoadedBytesCompleted(RESTClient.IRestResponse<byte[]> response)
    {
        if (response.IsError)
        {
            Debug.LogError("Error loading blob: " + response.ErrorMessage);
            return;
        }

        if (response.Data.Length > int.MaxValue)
        {
            throw new Exception("Stream is larger than can be copied into byte array");
        }

        LoadedStream = new MemoryStream(response.Data, 0, response.Data.Length, true, true);
    }




    




    //ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
    /*
    public bool MyRemoteCertificateValidationCallback(System.Object sender,
    X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain,
        // look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    continue;
                }
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                bool chainIsValid = chain.Build((X509Certificate2)certificate);
                if (!chainIsValid)
                {
                    isOk = false;
                    break;
                }
            }
        }
        return isOk;
    }
    */



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

/*
      XmlNode node1 = xmldoc.SelectSingleNode("//patientCase/annotation2/comment/text()");
      XmlNode node2 = xmldoc.SelectSingleNode("//patientCase/annotation3/comment/text()");
      XmlNode node3 = xmldoc.SelectSingleNode("//patientCase/lastEditedBy/text()");
      XmlNode node4 = xmldoc.SelectSingleNode("//patientCase/revisionNumber/text()");
      XmlNode node5 = xmldoc.SelectSingleNode("//patientCase/patientID/text()");
      XmlNode node6 = xmldoc.SelectSingleNode("//patientCase/DateAndTimeOfLastEdit/text()");
      XmlNode node7 = xmldoc.SelectSingleNode("//patientCase/patientAge/text()");

      */
//  _service = blobStorageConfig.Service;
// String resource = "{0}/{1}", container, file;
// xmldoc2 = _service.GetXmlBlob(LoadedBytesCompleted, resource);


// ILoader loader = null;
// loader = new BlobStorageLoader(blobStorageConfig.Service, container);