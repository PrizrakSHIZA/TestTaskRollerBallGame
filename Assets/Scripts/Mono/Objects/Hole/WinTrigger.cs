using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public bool win = false;

    private void OnCollisionEnter(Collision collision)
    {
        win = true;
    }
}
