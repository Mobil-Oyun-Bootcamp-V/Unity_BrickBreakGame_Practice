using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 _startPosition, _pullDistance;
    private bool _throwBall, _pullBall;

    public Vector2 PullDistance { get => _pullDistance; }
    public bool ThrowBall { get => _throwBall; }
    public bool PullBall { get => _pullBall; }

    void FixedUpdate()
    {
        _throwBall = false;
        _pullDistance = Vector2.zero;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                // take the first position / start to swipe
                case TouchPhase.Began:
                    _startPosition = touch.position;
                    _pullBall = true;
                    _throwBall = false;
                    //print("Touch Began");
                    break;

                // change swipe line synchronously
                case TouchPhase.Moved:
                    _pullDistance = touch.position - _startPosition;

                    _pullBall = true;
                    _throwBall = false;

                    //print("Touch Moved");
                    break;

                // take the last position / throw ball
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _pullDistance = touch.position - _startPosition;

                    _pullBall = false;
                    _throwBall = true;

                    //print("Touch Ended");
                    break;
            }
        }
    }
}
