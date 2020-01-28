using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PULoseMenu : PopUpMenu
{
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
