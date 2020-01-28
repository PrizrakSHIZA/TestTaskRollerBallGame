using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PUWinMenu : PopUpMenu
{
    //Its the same part as Retry() in PULoseMenu, but in future here can be differnces
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
