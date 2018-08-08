// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Academy
{
    public class AstronautManager : MonoBehaviour
      
    {
        private float expandAnimationCompletionTime;

        // Store a bool for whether our astronaut model is expanded or not.
        private bool isModelExpanding = false;

        public static List<GameObject> game_objects = new List<GameObject>();

        void Start()
        {
            Scene scene = SceneManager.GetActiveScene();
            scene.GetRootGameObjects(game_objects);

            Debug.Log(game_objects[2].name);
            Debug.Log(game_objects[3].name);

        }

        private void Update()
        {
            if (isModelExpanding && Time.realtimeSinceStartup >= expandAnimationCompletionTime)
            {
                isModelExpanding = false;
            }
        }



        public void ResetModelCommand()
        {

            foreach (GameObject g in game_objects)
            {
                if (g.name == "skin_Parent")
                {
                    Transform[] trans = g.GetComponentsInChildren<Transform>(true);
                    foreach (Transform t in trans)
                    {
                        t.gameObject.SetActive(true);
                    }
                }
            }

            foreach (GameObject g in game_objects)
            {
                if (g.name == "skinExpanded_Parent")
                {
                    Transform[] trans = g.GetComponentsInChildren<Transform>(true);
                    foreach (Transform t in trans)
                    {
                        t.gameObject.SetActive(false);
                    }
                }
            }


        }



            /*
            Transform[] trans2 = game_objects[3].GetComponentsInChildren<Transform>(true);
            foreach (Transform t2 in trans2)
            {
                t2.gameObject.SetActive(false);
            }
        */


            public void ExpandModelCommand()
        {

            foreach (GameObject g in game_objects)
            {
                if (g.name == "skin_Parent")
                {
                    Transform[] trans = g.GetComponentsInChildren<Transform>(true);
                    foreach (Transform t in trans)
                    {
                        t.gameObject.SetActive(false);
                    }
                }
            }

            foreach (GameObject g in game_objects)
            {
                if (g.name == "skinExpanded_Parent")
                {
                    Transform[] trans = g.GetComponentsInChildren<Transform>(true);
                    foreach (Transform t in trans)
                    {
                        t.gameObject.SetActive(true);
                    }
                }
            }

            /*

            Transform[] trans = game_objects[2].GetComponentsInChildren<Transform>(true);
            foreach (Transform t in trans)
            {
                t.gameObject.SetActive(false);
            }

            Transform[] trans2 = game_objects[3].GetComponentsInChildren<Transform>(true);
            foreach (Transform t2 in trans2)
            {
                t2.gameObject.SetActive(true);
            }
            
    */
        }

        public void buttonPressed()
        {
            Debug.Log("Button Pressed");
        }

        

    }
}