using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool
{
    private Queue<GameObject> _ballQueue;

    public void CreateBall(GameObject ball, int size, Transform parent)
    {
        _ballQueue = new Queue<GameObject>();
        GameObject insBall;

        for (int i = 0; i < size; i++)
        {
            insBall = GameObject.Instantiate(ball, parent);
            insBall.SetActive(false);
            _ballQueue.Enqueue(insBall);
        }
    }

    public GameObject GetBall()
    {
        GameObject temp = _ballQueue.Dequeue();
        temp.SetActive(true);
        _ballQueue.Enqueue(temp);
        return temp;
    }
}
