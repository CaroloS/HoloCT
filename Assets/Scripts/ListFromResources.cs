
using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

using UnityEngine.SceneManagement;


public class ListFromResources : MonoBehaviour {


	// Use this for initialization
	void Start () {

        Debug.Log("there are MEhSES: " + preLoadScene.MeshCount);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onSelectDocument()
    {
        string file = "new.xml";
        preLoadScene.blobName = file;

        TextAsset textAsset = (TextAsset)Resources.Load("new");
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);
        preLoadScene.xmldoc = xmldoc;

        Debug.Log("The xml has been set: " + "new.xml");
         countMeshNumber(preLoadScene.xmldoc);
    }

    public void onSelectDocument2()
    {
        string file = "new2.xml";
        preLoadScene.blobName = file;

        TextAsset textAsset = (TextAsset)Resources.Load("new2");
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);
        preLoadScene.xmldoc = xmldoc;

        Debug.Log("The xml has been set: " + "new2.xml");
        countMeshNumber(preLoadScene.xmldoc);
    }

    public void onSelectDocument3()
    {
        string file = "new3.xml";
        preLoadScene.blobName = file;

        TextAsset textAsset = (TextAsset)Resources.Load("new3");
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);
        preLoadScene.xmldoc = xmldoc;

        Debug.Log("The xml has been set: " + "new3.xml");
        countMeshNumber(preLoadScene.xmldoc);
    }
 



    public XDocument loadXMLFromResources(string fileName)
    {
        TextAsset textAsset = (TextAsset)Resources.Load(fileName);
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);
        return xmldoc;
    }



    private void countMeshNumber(XDocument xmldoc)
    {

        preLoadScene.MeshCount = 0;
        preLoadScene.meshes.Clear();

        foreach (XElement element in xmldoc.Descendants("mesh"))
        {
            preLoadScene.MeshCount++;
            preLoadScene.meshes.Add(element.Element("rawData").Value);
            Debug.Log(element.Element("rawData").Value);
            Debug.Log(preLoadScene.MeshCount);
        }

        SceneManager.LoadScene("dynamic");
    }

    public void exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
