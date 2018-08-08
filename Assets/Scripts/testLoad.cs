using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        List<XNode> xNodes = xmldoc.Element("patient").Element("patientCase").DescendantNodes().ToList();


        List<string> list = new List<string>();
        int count = 1;

        foreach (XElement element in xmldoc.Descendants("mesh"))
        {
            Debug.Log(count);
            string mmname = element.Attribute("id").Value.ToString();
            count++;

            
            list.Add(element.Element("rawData").Value);


            
        }

        Debug.Log(list[0]);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
