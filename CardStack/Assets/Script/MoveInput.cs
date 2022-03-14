using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    [SerializeField] JumpCard jumpDirection;
    private Vector2 startTouchPosition;
    private Vector2 currentTochPosition;
    private Vector2 endTouchPsition;
    private bool stopToch;

    private float swipRange;
    void Update()
    {
        Swipe();
    }

    void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;

        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            currentTochPosition = Input.GetTouch(0).position;
            Vector2 distance = currentTochPosition - startTouchPosition;
            if (distance.x < -swipRange)
            {
                jumpDirection.JumpDirection(0);

                stopToch = true;
            }
            if (distance.x > swipRange)
            {
                jumpDirection.JumpDirection(1);

                stopToch = true;
            }

        }
    }
}
