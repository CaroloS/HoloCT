using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityGLTF.Loader;

public class loadFromLocal : ILoader
{
    public Stream LoadedStream { get; private set; }

    public string _filename;

    public loadFromLocal(string filename)
    {
        _filename = filename;

    }

    public IEnumerator LoadStream(string _filename)
    {
        if (_filename == null)
        {
            throw new ArgumentNullException("Load Stream need a resources file");
        }

        Debug.Log("Load Resource: " + _filename);
        yield return getResource();
        
    }

    private string getResource()
    {

        TextAsset textAsset = (TextAsset)Resources.Load("new");
        
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);

        Debug.Log(xmldoc);

        var data = xmldoc.Element("patient").Element("patientCase").Element("meshes").Element("mesh").Element("rawData").Value;

        byte[] gltfBytes = System.Convert.FromBase64String(data);

        LoadedStream = new MemoryStream(gltfBytes, 0, gltfBytes.Length, true, true);

        return _filename;
        
  
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
