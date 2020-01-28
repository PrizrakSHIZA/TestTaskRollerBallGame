using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image progressbar;

    private int level;

    void Start()
    {
        level = Player.data.level;
        //Start loading level async
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation gamelevel = SceneManager.LoadSceneAsync(level);

        while (gamelevel.progress < 1)
        {
            //Fill progressbar while level loading
            progressbar.fillAmount = gamelevel.progress;
            yield return new WaitForEndOfFrame();
        }

    }
}
