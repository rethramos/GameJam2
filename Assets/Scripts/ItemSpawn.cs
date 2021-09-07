using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private Transform objectToSpawn;
    [SerializeField] private List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAtRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Chooses a random spawn point based on the given positions in spawnPoints
    // Make sure the list is not empty
    private void SpawnAtRandomPoint()
    {
        int i = Random.Range(0, spawnPoints.Count);
        Vector3 pos = spawnPoints[i].position;
        objectToSpawn.position = pos;
        Debug.Log(objectToSpawn.ToString() + " spawned at position " + pos);
    }
}
