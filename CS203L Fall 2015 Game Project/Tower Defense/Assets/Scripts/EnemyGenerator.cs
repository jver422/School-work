using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

    private int WinWaves = 40;

    public GameObject WinScreen;
    public GameObject EnemyNormal;
    public GameObject EnemyFast;
    public GameObject EnemyTank;
    public GameObject EnemyBoss;
    public static int Waves;
    public int EnemiesSpawned;
    public bool waveStarted;

    public AudioClip BossMusic;
    public AudioClip RegularMusic;

    private AudioSource source;

    private bool toggle = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(EnemyTimer());
        EnemiesSpawned = 0;
        Waves = 1;
        waveStarted = false;
        source = GetComponent<AudioSource>();
        source.clip = RegularMusic;
	}

    void Update()
    {
        if (!waveStarted)
            source.Pause();
        else
            source.Play();
        if (Waves >= WinWaves)
        {
            if ((GameObject.FindWithTag("Enemy") == null))
            {
                GameController.Win = true;
                WinScreen.SetActive(true);
            }
        }
    }

    void CreateEnemy()
    {
        float carry;
        // wave frequency
        if ((Waves % 3) == 0){
            // bolstered wave
            if (toggle)
            {
                EnemiesSpawned+=2;
            }else{
                EnemiesSpawned++;
            }
            toggle = !toggle;
            carry = 1f;
        }
        else if ((Waves % 5) == 0)
        {
            // swarm wave
            if (toggle)
            {
                EnemiesSpawned++;
            }
            toggle = !toggle;
            carry = 0f;
        }
        else
        {
            EnemiesSpawned++;
            carry = .5f;
        }

        // wave type
        GameObject enemy;
        if ((Waves % 10) == 0 && !waveStarted){
            // boss wave  
            enemy = Instantiate(EnemyBoss);
            enemy.GetComponent<EnemyController>().EnemyStats(Waves, 0, 1);
 
        }else if ((EnemiesSpawned - 5) % 5 == 0)
        {
            if (Waves % 2 == 0)
            {
                enemy = Instantiate(EnemyFast);
                enemy.GetComponent<EnemyController>().EnemyStats(Waves, 1, carry);
            }
            else
            {
                enemy = Instantiate(EnemyTank);
                enemy.GetComponent<EnemyController>().EnemyStats(Waves, 0, carry);
            }
        }else{ 
            enemy = Instantiate(EnemyNormal);
            enemy.GetComponent<EnemyController>().EnemyStats(Waves, .5f, carry);
        }
        enemy.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        
        if (!waveStarted)
        {
            waveStarted = true;
        }
    }

    IEnumerator EnemyTimer()
    {
        while (true)
        {
            //Todo: Use EnemySpeed variable
            int numFrames = 60;
            for (float i = 0f; i < numFrames; i += GameController.EnemySpeed)
            {
                while (Time.timeScale == 0) { yield return 0; }
                yield return 0;
            }
            if (Mathf.Sqrt(EnemiesSpawned) < (Waves + 2))
            {
                CreateEnemy();
            }
        }
    }

	public void NextWave()
    {

        if ((GameObject.FindWithTag("Enemy") == null) && waveStarted)
        {
            waveStarted = false;
            EnemiesSpawned = 0;
            Waves++;
            Debug.Log(Waves);
            toggle = true;
            if (Waves % 10 == 0)
                source.clip = BossMusic;
            else
                source.clip = RegularMusic;
        }
	}

}