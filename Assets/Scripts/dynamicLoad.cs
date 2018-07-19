using System.Net;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml;
using System;
using System.Collections;
using HoloToolkit.UX.ToolTips;

public class dynamicLoad : MonoBehaviour
{
  
    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected GameObject label;
    protected GameObject label1;
    protected GameObject label2;

    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected GameObject image;
    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected GameObject image1;
    [Tooltip("GameObject text that is displayed on the tooltip.")]
    [SerializeField]
    protected GameObject image2;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Hello");
        TextAsset textAsset = (TextAsset)Resources.Load("mhif");
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);

        XmlNode node = xmldoc.SelectSingleNode("//patientCase/annotation1/comment/text()");
        XmlNode node1 = xmldoc.SelectSingleNode("//patientCase/annotation2/comment/text()");
        XmlNode node2 = xmldoc.SelectSingleNode("//patientCase/annotation3/comment/text()");
        XmlNode node3 = xmldoc.SelectSingleNode("//patientCase/lastEditedBy/text()");
        XmlNode node4 = xmldoc.SelectSingleNode("//patientCase/revisionNumber/text()");
        XmlNode node5 = xmldoc.SelectSingleNode("//patientCase/patientID/text()");
        XmlNode node6 = xmldoc.SelectSingleNode("//patientCase/DateAndTimeOfLastEdit/text()");
        XmlNode node7 = xmldoc.SelectSingleNode("//patientCase/patientAge/text()");

        Debug.Log(node.Value);
        Debug.Log(node1.Value);
        Debug.Log(node2.Value);
        Debug.Log(node3.Value);
        Debug.Log(node4.Value);
        Debug.Log(node5.Value);
        Debug.Log(node6.Value);
        Debug.Log(node7.Value);

        TextMesh text = label.GetComponent<TextMesh>();
        text.text = node.Value;

        /*
        TextMesh text2 = label2.GetComponent<TextMesh>();
        text2.text = node1.Value;

        TextMesh text3 = label3.GetComponent<TextMesh>();
        text3.text = node3.Value;

        TextMesh text4 = label3.GetComponent<TextMesh>();
        text3.text = node3.Value;

        TextMesh text5 = label3.GetComponent<TextMesh>();
        text3.text = node3.Value;
        */
        Texture2D tex = (Texture2D)Resources.Load("lung_hist");
        ChangeImage(tex, image);

        Texture2D tex1 = (Texture2D)Resources.Load("brain_hist");
        ChangeImage(tex1, image1);

        Texture2D tex2 = (Texture2D)Resources.Load("brain_CT");
        ChangeImage(tex2, image2);
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
















    /*

       byte[] imageBytes = null;
       string someUrl = "https://holoctazureblobs.blob.core.windows.net/blob2/flower.jpg?sp=rw&st=2018-07-17T10:44:29Z&se=2018-07-17T18:44:29Z&sip=82.5.46.120&spr=https&sv=2017-11-09&sig=EjJn4OYUM70WFDTiaKFJF7nSqImzbvknAvDvhn%2F%2FmAQ%3D&sr=b";
       using (var webClient = new WebClient())
       {
           imageBytes = webClient.DownloadData(someUrl);
       }

       */


    

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