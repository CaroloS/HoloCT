using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class preLoadScene : MonoBehaviour {



	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Menu");
     //   HoloToolkit.Unity.in
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
