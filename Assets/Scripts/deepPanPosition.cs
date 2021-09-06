using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deepPanPosition : MonoBehaviour
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

        int rInt = Random.Range(0, 4);
        if (rInt == 0)
        {
            gameObjectToMove.transform.position = new Vector3(14.98f, 0.4f, 98.02f);
        }
        else if(rInt == 1)
        {
            gameObjectToMove.transform.position = new Vector3(16.51f, 3.05f, 86.85f);
        }
        else if(rInt == 2)
        {
            gameObjectToMove.transform.position = new Vector3(17.69f, 0.4f, 73.33f);
        }
        else if(rInt == 3)
        {
            gameObjectToMove.transform.position = new Vector3(13.76f, 1.56f, 73.33f);
        }
        else
        {
            gameObjectToMove.transform.position = new Vector3(-17.12f, 0.31f, 64.97f);
        }
        
    }
}
