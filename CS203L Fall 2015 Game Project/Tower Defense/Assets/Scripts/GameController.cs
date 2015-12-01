using UnityEngine;
using System.Collections;


public static class GameController : object
{
    /*
    private static EnemyController[] enemyControllers;
    static void Awake(){
        enemyControllers = GameObject.FindObjectsOfType(typeof(EnemyController));
    }
    */
    static void Start()
    {
        //debug.log((EnemyController)enemyControllers.EnemyAttacker());
    }
    public static int Difficulty { get; set; }
    public static float EnemySpeed { get; set; }
    public static float GameVolume { get; set; }
    public static float MusicVolume { get; set; }
    public static bool GameOver { get; set; }

    public static bool Win { get; set; }
    
    static GameController()
    {
        Difficulty = 1;
        EnemySpeed = 1.0f;
        GameVolume = 1.0f;
        MusicVolume = 1.0f;
        GameOver = false;
        Win = false;
    }
}