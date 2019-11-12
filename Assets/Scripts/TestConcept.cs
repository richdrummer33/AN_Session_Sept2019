using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConcept : MonoBehaviour
{
    SceneLoader mySceneLoader;

    public GameObject pictureObject;

    // Start is called before the first frame update
    void Start()
    {
        mySceneLoader.LoadScene("Session10_ArRuler");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
