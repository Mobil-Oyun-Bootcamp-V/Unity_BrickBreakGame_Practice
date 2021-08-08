using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector2 currentPos = new Vector2(-2.1f, 2.7f);
    private Vector2[] spawnPositions = new Vector2[7];
    [SerializeField] private GameObject _squareBrick, _triangleBrick1, _triangleBrick2, _triangleBrick3, _triangleBrick4;

    [System.Obsolete]
    void Awake()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            spawnPositions[i] = currentPos;
            SpawnRandom(spawnPositions[i]);
            currentPos.x += 0.7f;
        }
    }

    void FixedUpdate()
    {
        print(LevelManager.levelState + " --- " + GameManager.state);
        if (LevelManager.levelState == LevelManager.LevelState.next)
        {
            //for (int i = 0; i < spawnPositions.Length; i++)
            //{
            //    spawnPositions[i].y += 0.8f;
            //}
            LevelManager.level++;
            LevelManager.levelState = LevelManager.LevelState.stop;
            print("Level: " + LevelManager.level);
        }
    }

    [System.Obsolete]
    void SpawnRandom(Vector2 pos)
    {
        int rnd = Random.RandomRange(0, 6);
        //print(rnd);
        switch (rnd)
        {
            case 0:
                break;
            case 1:
                Instantiate(_squareBrick, pos, Quaternion.identity);
                break;
            case 2:
                Instantiate(_triangleBrick1, pos, Quaternion.identity);
                break;
            case 3:
                Instantiate(_triangleBrick2, pos, Quaternion.identity);
                break;
            case 4:
                Instantiate(_triangleBrick3, pos, Quaternion.identity);
                break;
            case 5:
                Instantiate(_triangleBrick4, pos, Quaternion.identity);
                break;
        }

    }
}
