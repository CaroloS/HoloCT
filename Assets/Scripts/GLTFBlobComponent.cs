//This class is adapted from:
//https://github.com/Unity3dAzure/StorageServicesGLTFDemo


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections;
using System.IO;
using GLTF;
using GLTF.Schema;
using UnityEngine;
using UnityGLTF.Loader;
using UnityGLTF;

namespace Azure.StorageServices
{

    /// <summary>
    /// Component to load a GLTF scene with
    /// </summary>
    public class GLTFBlobComponent : MonoBehaviour
    {
        [SerializeField]
        private BlobStorageConfig blobStorageConfig;
        public string container = null;
        public bool Multithreaded = true;
        public int MeshNum;

        [SerializeField]
        private bool loadOnStart = true;
        public int MaximumLod = 300;
        public GLTFSceneImporter.ColliderType Collider = GLTFSceneImporter.ColliderType.Mesh;

        [SerializeField]
        private Shader shaderOverride = null;


        void Start()
        {
            if (loadOnStart && blobStorageConfig.Ready)
            {
                if(preLoadScene.MeshCount >= MeshNum)
                {
                    StartCoroutine(Load());
                }
                
            }
        }

        public IEnumerator Load()
        {
            GLTFSceneImporter sceneImporter = null;
            ILoader loader = new loadFromXML(preLoadScene.blobName, MeshNum);

            sceneImporter = new GLTFSceneImporter(preLoadScene.blobName, loader);

            sceneImporter.SceneParent = gameObject.transform;
            sceneImporter.Collider = Collider;
            sceneImporter.MaximumLod = MaximumLod;
            sceneImporter.CustomShaderName = shaderOverride ? shaderOverride.name : null;
            yield return sceneImporter.LoadScene(-1, Multithreaded);

            // Override the shaders on all materials if a shader is provided
            if (shaderOverride != null)
            {
                Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in renderers)
                {
                    renderer.sharedMaterial.shader = shaderOverride;
                }
            }
        }
    }
}
