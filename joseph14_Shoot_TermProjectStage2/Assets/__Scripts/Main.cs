using System.Collections; // Required for Arrays & other Collections
using System.Collections.Generic; // Required to use Lists or Dictionaries
using UnityEngine; // Required for Unity
using UnityEngine.SceneManagement; // For loading & reloading of scenes
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // Static members that need to be accessed across the game
    public static bool isPlaying = true;
    public static int score = 0;
    public static int Enemy0Total = 0;
    public static int Enemy1Total = 0;
    public static int Enemy2Total = 0;
    public static int Enemy3Total = 0;
    public static int Enemy4Total = 0;
    public static int damage0 = 5, damage1 = 10, damage2 = 15, damage3 = 20, damage4 = 25;
    public static GameLevel[] gv;
    public static int currLevel = 0;
    public Text levelText;
    public GameObject[] enemiesTest;
    public static AudioSource[] sounds;

    static public Main S; // A singleton for Main
    static Dictionary<WeaponType, WeaponDefinition> WEAP_DICT; // a
    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies; // Array of Enemy prefabs
    public float enemySpawnPerSecond = 0.5f; // # Enemies/second
    public float enemyDefaultPadding = 1.5f; // Padding for position
    public WeaponDefinition[] weaponDefinitions;
    public GameObject prefabPowerUp; // a
    public WeaponType[] powerUpFrequency = new WeaponType[] { // b
    WeaponType.blaster, WeaponType.blaster,
    WeaponType.spread, WeaponType.shield };

    private BoundsCheck bndCheck;

    public void shipDestroyed(Enemy e)
    { // c
        playDestroySound();
      // Potentially generate a PowerUp
        if (Random.value <= e.powerUpDropChance)
        { // d
          // Choose which PowerUp to pick
          // Pick one from the possibilities in powerUpFrequency
            int ndx = Random.Range(0, powerUpFrequency.Length); // e
            WeaponType puType = powerUpFrequency[ndx];
            // Spawn a PowerUp
            GameObject go = Instantiate(prefabPowerUp) as GameObject;
            PowerUp pu = go.GetComponent<PowerUp>();
            // Set it to the proper WeaponType
            pu.SetType(puType); // f
                                // Set it to the position of the destroyed ship
            pu.transform.position = e.transform.position;
        }

        if (e is Enemy_1)
        {
            Main.Enemy1Total++;
            Main.score += Main.damage1;
        }
        else if (e is Enemy_2)
        {
            Main.Enemy2Total++;
            Main.score += Main.damage2;

        }
        else if (e is Enemy_3)
        {
            Main.Enemy3Total++;
            Main.score += Main.damage3;

        }
        else if (e is Enemy_4)
        {
            Main.Enemy4Total++;
            Main.score += Main.damage4;

        }
        else if (e is Enemy)
        {
            Main.Enemy0Total++;
            Main.score += Main.damage0;
        }
    }

    void Awake()
    {
        sounds = GetComponents<AudioSource>();
        stopAllSounds();
        playBGMusic();
        S = this;
        WEAP_DICT = new Dictionary<WeaponType, WeaponDefinition>(); // a
        bndCheck = GetComponent<BoundsCheck>();
        // Set bndCheck to reference the BoundsCheck component on this GameObject
        // Invoke SpawnEnemy() once (in 2 seconds, based on default values)
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); // a
        foreach (WeaponDefinition def in weaponDefinitions)
        { // b
            WEAP_DICT[def.type] = def;
        }   
    }

    public static void playBGMusic()
    {
        int index = 0;

        if (AudioMenuScript.d1Val == 0)
        {
            index = 0;
        }
        else if(AudioMenuScript.d1Val == 1)
        {
            index = 1;
        }
        else
        {
            index = 2;
        }
        sounds[index].volume = AudioMenuScript.d1Vol;
        sounds[index].Play();
    }

    public static void playWinSound()
    {
        int index = 8;

        if (AudioMenuScript.d2Val == 0)
        {
            index = 8;
        }
        else
        {
            index = 9;
        }

        sounds[index].volume = AudioMenuScript.d2Vol;
        sounds[index].Play();
    }

    public static void playShootSound()
    {
        int index = 3;
        if (AudioMenuScript.d3Val == 0)
        {
            index = 3;
        }
        else if(AudioMenuScript.d3Val == 1)
        {
            index = 4;
        }

        if (!sounds[index].isPlaying)
        {
            sounds[index].volume = AudioMenuScript.d3Vol;
            sounds[index].Play();
        }
    }

    public static void playDestroySound()
    {
        int index = 5;
        if (AudioMenuScript.d4Val == 0)
        {
            index = 5;
        }
        else if (AudioMenuScript.d4Val == 1)
        {
            index = 6;
        }
        else if (AudioMenuScript.d4Val == 2)
        {
            index = 7;
        }

        sounds[index].volume = AudioMenuScript.d4Vol;
        sounds[index].Play();     
    }

    public void SpawnEnemy()
    {
        if (enemiesTest.Length < gv[currLevel].MaxEnemies)
        {
            // Pick a random Enemy prefab to instantiate
            int ndx;
            while (true)
            {
                ndx = Random.Range(0, prefabEnemies.Length); // b
                if (gv[currLevel].arr[ndx] == true) break;
            }
            GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]); // c
                                                                         // Position the Enemy above the screen with a random x position

            float enemyPadding = enemyDefaultPadding; // d
            if (go.GetComponent<BoundsCheck>() != null)
            { // e
                enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
            }
            // Set the initial position for the spawned Enemy // f
            Vector3 pos = Vector3.zero;
            float xMin = -bndCheck.camWidth + enemyPadding;
            float xMax = bndCheck.camWidth - enemyPadding;
            pos.x = Random.Range(xMin, xMax);
            pos.y = bndCheck.camHeight + enemyPadding;
            go.transform.position = pos;
            // Invoke SpawnEnemy() again
            Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); // g
        }
        else
        {
            Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); // g
        }

    }

    public void DelayedRestart(float delay)
    {
        // Invoke the Restart() method in delay seconds
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        // Reload _Scene_0 to restart the game
        score = 0;
        Enemy0Total = 0;
        Enemy1Total = 0;
        Enemy2Total = 0;
        Enemy3Total = 0;
        Enemy4Total = 0;
        SceneManager.LoadScene("_Scene_0");
    }


    static public WeaponDefinition GetWeaponDefinition(WeaponType wt)
    { //a
        // Check to make sure that the key exists in the Dictionary
        // Attempting to retrieve a key that didn't exist, would throw an error,
        // so the following if statement is important.
        if (WEAP_DICT.ContainsKey(wt))
        { // b
            return (WEAP_DICT[wt]);
        }
        // This returns a new WeaponDefinition with a type of WeaponType.none,
        // which means it has failed to find the right WeaponDefinition
        return (new WeaponDefinition()); // c
    }
    
    public void Update()
    {
        enemiesTest = GameObject.FindGameObjectsWithTag("Enemy");
        setText();

        if (score >= gv[currLevel].score)
        {
           playWinSound();
           currLevel++;
           DestroyAllObjects();
        }  
    }

    public void setText()
    {
        if (currLevel == 0)
        {
            levelText.text = "Bronze";
        }
        else if (currLevel == 1)
        {
            levelText.text = "Silver";

        }
        else if (currLevel == 2)
        {
            levelText.text = "Gold";
        }
        else if(currLevel == 3)
        {
            levelText.text = "*Infinite*";
        }
        else
        {
            Debug.Log("Fatal Error!!!!!");
        }
    }

    public static void DestroyAllObjects()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in enemies)
        {
            Destroy(e);
        }

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("ProjectilePlayer");
        foreach (GameObject b in bullets)
        {
            Destroy(b);
        }

    }

    public static void stopAllSounds()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();
        }
    }    
}