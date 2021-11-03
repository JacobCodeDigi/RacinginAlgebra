using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MathsMenu : MonoBehaviour
{
    public GameObject Maths;

    void Start() {
        Maths.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "finishline") {
            Maths.gameObject.SetActive( true );
            Time.timeScale = 0f;
        }
    }
}

