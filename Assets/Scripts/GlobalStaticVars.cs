using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalStaticVars
{
    public static float enemyHP { get; set; } = 3f;
    public static float enemyMS { get; set; } = 2f;

    public static int enemyNumber { get; set; } = 10;
    public static int playerHP { get; set; } = 100;
    public static int playerAttack { get; set; } = 1;
    public static int playerPoints { get; set; } = 0;

    public static List<GameObject> skills { get; set; } = new List<GameObject>();
    public static bool hasViewedTutorial { get; set; } = false;
    public static int level { get; set; } = 1;
    public static bool GameStart { get; set; } = true;

    public static bool skipTutorial { get; set; } = false;
    public static bool hasViewedEnemyTutorial { get; set; } = false;
    public static bool hasViewedEnergyTutorial { get; set; } = false;
    public static bool hasViewedYYBarTutorial { get; set; } = false;
    public static bool hasViewedSkillTutorial { get; set; } = false;
    public static bool hasViewedHPBarTutorial { get; set; } = false;
    public static bool hasViewedRewardTutorial { get; set; } = false;

    public static float LevelTime { get; set; } = 0;
    public static float tutorialTime { get; set; } = 0;
    public static bool inTutorial { get; set; } = false;
}
