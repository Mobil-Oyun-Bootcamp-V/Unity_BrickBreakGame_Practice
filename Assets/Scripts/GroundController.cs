using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetType() == typeof(CircleCollider2D))
        { 
            if (other.transform.GetComponent<BallController>())
            {
                print("Main Ball");
                other.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                other.transform.position = new Vector2(0, -3.825f);
                LevelManager.levelState = LevelManager.LevelState.stop;
            }
            else
            {
                //print("Prefab");
                other.gameObject.SetActive(false);
            }
            
        }
    }

}
