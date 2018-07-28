using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameObject object2;

	// Use this for initialization
	void Start () {

        //    object2 = Object.FindObjectOfType<InputManager>;

        //object2 = SceneManager.GetSceneByName("preLoadScene").GetRootGameObjects()
	}
	
	

    public void load_Static_Scene()
    {
      SceneManager.LoadScene("Origami");
    }

    public void load_Dynamic_Scene()
    {
        SceneManager.LoadScene("ListScene");
    }


// Update is called once per frame
	void Update () {
		
	}
}
