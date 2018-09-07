using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityGLTF.Loader;

public class loadFromXML : ILoader
{
    public Stream LoadedStream { get; private set; }

    public string _filename;
    public int _MeshNumber;

    public loadFromXML(string filename, int MeshNumber)
    {
        _filename = filename;
        _MeshNumber = MeshNumber;
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
        var data = preLoadScene.meshes[_MeshNumber - 1];

        byte[] gltfBytes = System.Convert.FromBase64String(data);

        LoadedStream = new MemoryStream(gltfBytes, 0, gltfBytes.Length, true, true);

        return _filename;


    }

}




