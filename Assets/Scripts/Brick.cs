using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private int _health;
    private TextMeshPro _txtHealth;
    void Awake()
    {
        LevelManager.levelState = LevelManager.LevelState.stop;
        _health = LevelManager.level;
        _txtHealth = GetComponentInChildren<TextMeshPro>();
    }

    void FixedUpdate()
    {
        _txtHealth.text = _health.ToString();
        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void TakeDamage(int damage)
    {
        _health -= damage;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.collider.GetType() == typeof(CircleCollider2D))
        {
            TakeDamage(1);
        }
    }
}
