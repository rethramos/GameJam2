using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifePosition : MonoBehaviour
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
            gameObjectToMove.transform.position = new Vector3(-10.7f, -0.44f, 20.87f);
        }
        else if (rInt == 1)
        {
            gameObjectToMove.transform.position = new Vector3(-2.41f, 0.155f, 17.841f);
        }
        else
        {
            gameObjectToMove.transform.position = new Vector3(7.947f, 1.38f, 42.45f);
        }

    }
}
