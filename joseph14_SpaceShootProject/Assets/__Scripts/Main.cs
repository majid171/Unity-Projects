using System.Collections; // Required for Arrays & other Collections
using System.Collections.Generic; // Required to use Lists or Dictionaries
using UnityEngine; // Required for Unity
using UnityEngine.SceneManagement; // For loading & reloading of scenes

public class Main : MonoBehaviour
{
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
    }

    void Awake()
    {
        S = this;
        // Set bndCheck to reference the BoundsCheck component on this GameObject
        bndCheck = GetComponent<BoundsCheck>();
        // Invoke SpawnEnemy() once (in 2 seconds, based on default values)
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); // a
        WEAP_DICT = new Dictionary<WeaponType, WeaponDefinition>(); // a
        foreach (WeaponDefinition def in weaponDefinitions)
        { // b
            WEAP_DICT[def.type] = def;
        }
    }
    public void SpawnEnemy()
    {
        // Pick a random Enemy prefab to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length); // b
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

    public void DelayedRestart(float delay)
    {
        // Invoke the Restart() method in delay seconds
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        // Reload _Scene_0 to restart the game
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


}