using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> _gameObjectQueue;
    public List<ObjectType> _objectQueue;

    void Awake()
    {
        _gameObjectQueue = new List<GameObject>();
        foreach (ObjectType objTyp in _objectQueue)
        {
            CreateBrick(objTyp.obj, objTyp.amount);
        }
    }

    public void CreateBrick(GameObject obj, int size)
    {
        GameObject insObj;

        for (int i = 0; i < size; i++)
        {
            insObj = GameObject.Instantiate(obj, transform);
            insObj.SetActive(false);
            _gameObjectQueue.Add(insObj);
        }
    }

    //public GameObject GetBrick()
    //{
    //    GameObject temp = _gameObjectQueue.Dequeue();
    //    temp.SetActive(true);
    //    _gameObjectQueue.Enqueue(temp);
    //    return temp;
    //}
}
