using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static PlayerData data;

    //Clear all player stats and make his profile as new
    public static void ClearStats()
    {
        data.level = 2;
    }
}
