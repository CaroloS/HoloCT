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
