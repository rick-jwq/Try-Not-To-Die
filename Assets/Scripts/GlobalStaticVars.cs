﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalStaticVars
{
    public static float enemyHP { get; set; } = 3f;
    public static float enemyMS { get; set; } = 2f;
    public static int playerHP { get; set; } = 100;
    public static int playerAttack { get; set; } = 1;
    public static int playerPoints { get; set; } = 0;
    public static bool hasViewedTutorial { get; set; } = false;
}
