using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemonPosiition : MonoBehaviour
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
            gameObjectToMove.transform.position = new Vector3(10.303f, -0.9f, 59.6f);
        }
        else if (rInt == 1)
        {
            gameObjectToMove.transform.position = new Vector3(-10.75f, -0.9f, 61.59f);
        }
        else
        {
            gameObjectToMove.transform.position = new Vector3(-9.01f, 1f, 60.062f);
        }

    }
}
