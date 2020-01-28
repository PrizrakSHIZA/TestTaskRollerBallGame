using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button[] buttons;
    Button button;

    private void Start()
    {
        //Try to load saved file, if it exists
        PlayerData data = SaveSystem.Load();
        if (data != null)
        {
            Player.data = data;
        }
        else
        {
            Debug.Log("Create new Data");
            Player.data = new PlayerData();
            Debug.Log(Player.data.level);
        }

        //This part of code, about finding needed button also can be done while making Button variable as public, and assigning needed button in editor
        //that  would be simple, but if UI will be change, and button gameobjec will be destroyed it will be needed to reassigned again. The methid below
        //is more complicated but will work in any ui with button named "ContinueButton"
        buttons = FindObjectsOfType<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == "ContinueButton")
            {
                button = buttons[i];
            }
        }

        //Check if player is on first level(№2 in scenemanager) disable continue button 
        if (Player.data.level == 2)
        {
            button.interactable = false;
        }

    }

    public void CloseGame()
    {
        Application.Quit();
    }
    //Clear player stats, and begin new game
    public void NewGame()
    {
        Player.ClearStats();
        SaveSystem.Save();
        SceneManager.LoadScene(1);
    }
    //Continue game from last uncompleted level
    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
}
