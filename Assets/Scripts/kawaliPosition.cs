using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kawaliPosition : MonoBehaviour
{
    public GameObject gameObjectToMove;
    // Start is called before the first frame update
    void Start()
    {
        MoveGameObject();
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
            gameObjectToMove.transform.position = new Vector3(30.65f, 1.34f, 24.59f);
        }
        else if (rInt == 1)
        {
            gameObjectToMove.transform.position = new Vector3(40.844f, -0.82f, 48.521f);
        }
        else
        {
            gameObjectToMove.transform.position = new Vector3(21.48f, 0.12f, 55.95f);
        }

    }
}
