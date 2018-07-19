using RESTClient;
using Azure.StorageServices;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using System.Net;

public class ImageDemo : MonoBehaviour
{

  [Header("Azure Storage Service")]
  [SerializeField]
  private string storageAccount;
  [SerializeField]
  private string accessKey;
  [SerializeField]
  private string container;

  private StorageServiceClient client;
  private BlobService blobService;

  [Header("Image Demo")]
  public Image image;
  public Text label;

  private bool isCaptured = true;

  private string localPath;

  void Start()
  {
    if (string.IsNullOrEmpty(storageAccount) || string.IsNullOrEmpty(accessKey))
    {
      Log.Text(label, "Storage account and access key are required", "Enter storage account and access key in Unity Editor", Log.Level.Error);
    }
    
    
   
  }

  void Update()
  {
  }

 

  private void DisplayImage()

  {
        byte[] imageBytes = null;

        string someUrl = "https://holoctazureblobs.blob.core.windows.net/blob2/flower.jpg?sp=rw&st=2018-07-17T10:44:29Z&se=2018-07-17T18:44:29Z&sip=82.5.46.120&spr=https&sv=2017-11-09&sig=EjJn4OYUM70WFDTiaKFJF7nSqImzbvknAvDvhn%2F%2FmAQ%3D&sr=b";
        using (var webClient = new WebClient())
        {
            imageBytes = webClient.DownloadData(someUrl);
        }



    Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    texture.LoadImage(imageBytes);
    ChangeImage(texture);
  }



  private void ChangeImage(Texture2D texture)
  {
    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    image.GetComponent<Image>().sprite = sprite;
  }

  private void ChangeImage(Texture texture)
  {
    ChangeImage(texture as Texture2D);
  }



  public void TappedNext()
  {
    SceneManager.LoadScene("ListScene");
  }
}
