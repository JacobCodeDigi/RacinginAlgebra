using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0f;
            Pause.gameObject.SetActive( true );

        }
    }
    public void Resume() {
        Time.timeScale = 1f;
        Pause.gameObject.SetActive( false );
    }
}
