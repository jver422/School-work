using UnityEngine;
using System.Collections;

public static class GameController {

    public static float EnemySpeed { get; set; }
    static GameController()
    {
        EnemySpeed = 1.0f;
    }
}