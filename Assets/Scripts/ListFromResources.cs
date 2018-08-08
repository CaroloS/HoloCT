
using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

using UnityEngine.SceneManagement;


public class ListFromResources : MonoBehaviour {


	// Use this for initialization
	void Start () {

        Debug.Log("there are MEhSES: " + dynamicLoad.MeshCount);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onSelectDocument()
    {
        string file = "new.xml";
        dynamicLoad.blobName = file;

        TextAsset textAsset = (TextAsset)Resources.Load("new");
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);
        dynamicLoad.xmldoc = xmldoc;

        Debug.Log("The xml has been set: " + "new.xml");
         countMeshNumber(dynamicLoad.xmldoc);
    }

    public void onSelectDocument2()
    {
        string file = "new2.xml";
        dynamicLoad.blobName = file;

        TextAsset textAsset = (TextAsset)Resources.Load("new2");
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);
        dynamicLoad.xmldoc = xmldoc;

        Debug.Log("The xml has been set: " + "new2.xml");
        countMeshNumber(dynamicLoad.xmldoc);
    }

    public void onSelectDocument3()
    {
        string file = "new3.xml";
        dynamicLoad.blobName = file;

        TextAsset textAsset = (TextAsset)Resources.Load("new3");
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);
        dynamicLoad.xmldoc = xmldoc;

        Debug.Log("The xml has been set: " + "new3.xml");
        countMeshNumber(dynamicLoad.xmldoc);
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

        dynamicLoad.MeshCount = 0;
        dynamicLoad.meshes.Clear();

        foreach (XElement element in xmldoc.Descendants("mesh"))
        {
            dynamicLoad.MeshCount++;
            dynamicLoad.meshes.Add(element.Element("rawData").Value);
            Debug.Log(element.Element("rawData").Value);
            Debug.Log(dynamicLoad.MeshCount);
        }

        SceneManager.LoadScene("dynamic");
    }

    public void exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
