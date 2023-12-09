using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
  public GameObject pause;
    bool isPause;
    void Start()
    {
        pause.SetActive(false);
    }

  
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) 
        {
            if(isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
     public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void Resume()
    {
        pause.SetActive(false);
            Time.timeScale = 1f;    
        isPause = false;

    }
    
}
