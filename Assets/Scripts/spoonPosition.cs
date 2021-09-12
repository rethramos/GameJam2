using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spoonPosition : MonoBehaviour
{
    public GameObject gameObjectToMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveGameObject()
    {
        gameObjectToMove.SetActive(true);

        int rInt = Random.Range(0, 2);
        if (rInt == 0)
        {
            gameObjectToMove.transform.position = new Vector3(38.537f, 1.147f, 23.993f);
        }
        else if (rInt == 1)
        {
            gameObjectToMove.transform.position = new Vector3(41.278f, -0.986f, 24.087f);
        }
        else
        {
            gameObjectToMove.transform.position = new Vector3(-4.97f, 0.22f, 81.75f);
        }
    }
    }
