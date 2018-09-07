using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class preLoadScene : MonoBehaviour {

    public static string blobName;
    public static XDocument xmldoc = new XDocument();
    public static int MeshCount = 0;
    public static List<string> meshes = new List<string>();


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Menu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
