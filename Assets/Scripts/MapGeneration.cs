using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject[] maps;
    private float spawnPos = 0;
    private float mapSize = 83; //needs standartization
    private List<GameObject> activeMaps = new List<GameObject>();

    [SerializeField] private Transform player;
    private int startBlocks = 2;

    private void SpawnMap(int mapIndex)
    {
        GameObject nextMap = Instantiate(maps[mapIndex], transform.forward * spawnPos, transform.rotation);
        activeMaps.Add(nextMap);
        spawnPos += mapSize;
    }

    private void DeleteMap()
    {
        Destroy(activeMaps[0]);
        activeMaps.RemoveAt(0);
    }
    
    void Start()
    {
        for (int i = 0; i < startBlocks; i++)
        {
            if (i == 0)
                SpawnMap(30);
            SpawnMap(Random.Range(0, maps.Length - 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > spawnPos - (startBlocks * mapSize))
        {
            SpawnMap(Random.Range(0, maps.Length - 1));
            DeleteMap();
        }
    }
}
