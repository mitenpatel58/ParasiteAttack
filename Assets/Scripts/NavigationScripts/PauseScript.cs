using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : BaseClass
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        Debug.Log("resume");
        ScreenManager.inst.ShowNextScreen(ScreenType.PlayerController);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AddSensitivity()
    {
        CameraController.instance.sensitivity++;
    }

    public void SubSenitivity()
    {
        CameraController.instance.sensitivity--;
    }
}
