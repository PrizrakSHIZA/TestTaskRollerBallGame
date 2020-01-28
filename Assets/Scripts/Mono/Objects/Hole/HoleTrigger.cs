using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        col.gameObject.layer = 9;
    }

    private void OnTriggerExit(Collider col)
    {
        col.gameObject.layer = 0;
    }
}
