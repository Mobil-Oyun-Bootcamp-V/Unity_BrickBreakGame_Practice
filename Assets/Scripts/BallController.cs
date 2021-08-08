using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject _pullLine;
    [SerializeField] private InputManager _inputManager;

    private const float maxPull = 160f;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pullLine.SetActive(false);
    }

    void FixedUpdate()
    {
        ThrowBall();
    }

    void ThrowBall()
    {
        Vector2 pullDist = _inputManager.PullDistance;
        pullDist *= -1;

        if (pullDist != Vector2.zero)
        {
            if (pullDist.y <= transform.position.y)
                _pullLine.SetActive(false);

            else
            {
                _pullLine.transform.up = pullDist.normalized;
                _pullLine.SetActive(true);
                _pullLine.transform.localScale = Vector2.Lerp(new Vector2(1, 1), new Vector2(1.5f, 1.5f), pullDist.magnitude / maxPull);

                if (_inputManager.ThrowBall)
                {
                    _pullLine.SetActive(false);
                    _rb.AddForce(pullDist.normalized * 1250);
                    GameManager.state = GameManager.GameState.Start;
                    if (GameManager.state == GameManager.GameState.Start)
                        LevelManager.levelState = LevelManager.LevelState.next;
                    //BallPool bp = new BallPool;
                }
            }
        }
    }
}
