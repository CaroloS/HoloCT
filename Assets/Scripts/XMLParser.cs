using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class XMLParser : MonoBehaviour {

    public static List<string> imageTags = new List<string>();

    // Use this for initialization
    void Start () {	
	}

    public static List<string> parseMetaData()
    {
        List<string> metadata = new List<string>();

        foreach (XElement element in preLoadScene.xmldoc.Descendants("patientCase"))
        {
            metadata.Add(element.Element("patientAge").Value);
            metadata.Add(element.Element("revisionNumber").Value);
            metadata.Add(element.Element("lastEditedBy").Value);
            metadata.Add(element.Element("DateAndTimeOfLastEdit").Value);
        }
        return metadata;
    }
	

    public static List<string> parseImageAnnotation()
    {
        List<string> imageAnnotations = new List<string>();
      //  List<string> tags = new List<string>();

        var hasAnnotation = preLoadScene.xmldoc.Descendants("annotation");

        if (hasAnnotation != null)
        {
            foreach (XElement element1 in preLoadScene.xmldoc.Descendants("annotationData"))
            {
                string type = element1.Attribute("type").Value.ToString();
                string tag = element1.Attribute("tag").Value.ToString();

                if (type == "image")
                {
                    string CurrentValue = (string)element1;
                    imageAnnotations.Add(CurrentValue);
                    imageTags.Add(tag);
                }
            }
        }
        return imageAnnotations;
    }

}
