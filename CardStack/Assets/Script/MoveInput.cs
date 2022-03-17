using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    [SerializeField] JumpCard jumpDirection;
    private Vector2 startTouchPosition;
    private Vector2 currentTochPosition;
    private bool right=false;
    private bool left=true;

    private float swipRange=0;
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
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTochPosition = Input.GetTouch(0).position;
            Vector2 distance = currentTochPosition - startTouchPosition;
            if (distance.x < -swipRange && left)
            {
                left = false;
                right = true;
                jumpDirection.JumpDirection(0);


            }
            if (distance.x > swipRange && right)
            {
                left = true;
                right = false;
                jumpDirection.JumpDirection(1);


            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTochPosition = Input.GetTouch(0).position;
            Vector2 distance = currentTochPosition - startTouchPosition;
            if (distance.x < -swipRange)
            {
                left = false;
                right = true;
                jumpDirection.JumpDirection(0);


            }
            if (distance.x > swipRange)
            {
                left = true;
                right = false;
                jumpDirection.JumpDirection(1);


            }
        }


    }
}
