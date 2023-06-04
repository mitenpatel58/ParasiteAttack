using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionScript : BaseClass
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        ScreenManager.inst.ShowNextScreen(ScreenType.PlayerController);
    }
}
