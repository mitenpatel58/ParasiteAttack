using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : BaseClass
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        Debug.Log("Pause");
        ScreenManager.inst.ShowNextScreen(ScreenType.PauseScreen);
        Time.timeScale = 0f;
    }
}
