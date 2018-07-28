using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class testLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
       
        TextAsset textAsset = (TextAsset)Resources.Load("new");
        
        XDocument xmldoc = new XDocument();
        xmldoc = XDocument.Parse(textAsset.text);

        Debug.Log(xmldoc);
        
        var data = (string)xmldoc.Element("patient").Element("patientCase").Element("annotation1").Element("author");

        //   XmlNode node = xmldoc.SelectSingleNode("//patientCase/annotation1/author/text()");
        Debug.Log(data);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
