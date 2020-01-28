using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    [Space(10)]
    //Getting ball rigit body to make it non kinematic
    [Tooltip("Ball rigit body")]
    public Rigidbody ball;
    [Tooltip("Trigger that must be in hole prefab")]
    public WinTrigger winTrigger;
    public Animator LoseMenu, WinMenu;
    public Window_Confetti wconfetti;
    [Space(10)]

    [Header("Timers settings")]
    [Tooltip("Main timer text")]
    public Text timer;
    [Tooltip("Pretimer timer text")]
    public Text pretimer;
    [Tooltip("Seconds from which timer starts")]
    public float starttime = 10f, pretimerstart = 5f;
    [Tooltip("Word will be displayed before time with \": \"")]
    public string word = "Text";
    [Tooltip("Style determine how time will be displayed")]
    public string style = "0.0";
    [Space(10)]

    [Header("Sound settings")]
    public AudioClip winsound;
    public AudioClip losesound;
    AudioSource audiosource;

    bool started = false, finished = false, PTfinsihed = false;
    float currenttime = 0f;

    private void Start()
    {
        //Timers setup
        currenttime = pretimerstart;
        word = word + ": ";
        //Sound setup
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (winTrigger.win && !finished)
        {
            finished = true;
            WinMenu.SetTrigger("Open");
            wconfetti.win = true;
            audiosource.Stop();
            audiosource.PlayOneShot(winsound);
            Player.data.level++;
            SaveSystem.Save();
        }
        //pretimer is timer to give player to get ready. While this timer working no controler gived
        if (!PTfinsihed)
        {
            currenttime -= Time.deltaTime;
            pretimer.text = currenttime.ToString("0");
            if (currenttime <= 0)
            {
                currenttime = starttime;
                PTfinsihed = true;
                pretimer.enabled = false;
                ball.isKinematic = false;
                StartTimer();
            }
        }
        //give control of ball and start level timer
        if (started && !finished)
        {
            currenttime -= Time.deltaTime;
            timer.text = word + currenttime.ToString(style);
            if (currenttime <= 0)
            {
                currenttime = 0;
                finished = true;
                LoseMenu.SetTrigger("Open");
                audiosource.Stop();
                audiosource.PlayOneShot(losesound);
            }
        }
    }

    public void StartTimer()
    {
        started = true;
    }
}
