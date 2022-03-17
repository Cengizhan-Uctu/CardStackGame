using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class JumpCard : MonoBehaviour
{
    [SerializeField] GameObject rightHend;
    [SerializeField] GameObject lesftHend;
    Vector3 rightHendDefauldPos;
    Vector3 leftHendDefauldPos;
    bool moveDelayLeft = true;
    bool moveDelayRight = true;
    bool repeatJumpLeft;
    bool repeatJumpRight = true;
    public static bool isCountChange;
    Sequence sequence;

    void Start()
    {

        DOTween.Init();
        rightHendDefauldPos = rightHend.transform.localPosition;
        leftHendDefauldPos = lesftHend.transform.localPosition;

    }


    IEnumerator SwichUpCards(int kindMove)
    {
        if (kindMove == 0 && moveDelayLeft && !repeatJumpLeft)
        {
            JumpCard.isCountChange = false;
            for (int i = CardCountChange.cards.Count - 1; i >= 0; i--)
            {
               
                JumpLeft(i);
                yield return new WaitForSeconds(.04f);

            }
        }
        if (kindMove == 1 && moveDelayRight && !repeatJumpRight)
        {

            JumpCard.isCountChange = false;
            for (int i = 0; i <= CardCountChange.cards.Count - 1; i++)
            {
               
                JumpRight(i);
                yield return new WaitForSeconds(.04f);

            }
        }

    }
    void JumpRight(int i)
    {
        repeatJumpRight = true;
        moveDelayLeft = false;
        leftHendDefauldPos.y += 0.15f;
        if (i == 0)
        {
            sequence.Append(CardCountChange.cards[i].transform.DOLocalJump(leftHendDefauldPos, 2.5f, 1, 0.4f));
            sequence.Join(CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(0, 0, 0), 0.4f, RotateMode.FastBeyond360)
                .SetDelay(0.5f)
                .OnComplete(() => CheckAnimadionEndRight()));
            sequence.Join(CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(10, 0, 0), 0.4f, RotateMode.FastBeyond360));
            return;
        }

        sequence.Append(CardCountChange.cards[i].transform.DOLocalJump(leftHendDefauldPos, 2.5f, 1, 0.4f)
            .OnComplete(() => CardCountChange.cards[i].transform.DOPunchScale(new Vector3(.18f, 0, .18f), 0.2f)));
        sequence.Join(CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(0, 0, 0), 0.4f, RotateMode.FastBeyond360));
        sequence.Join(CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(10, 0, 0), 0.4f, RotateMode.FastBeyond360)
            .OnComplete(() => CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f, RotateMode.FastBeyond360)));

    }
    void JumpLeft(int i)
    {
       
        repeatJumpLeft = true;
        moveDelayRight = false;
        rightHendDefauldPos.y += 0.15f;
        if (i == CardCountChange.cards.Count - 1)
        {
            sequence.Append(CardCountChange.cards[i].transform.DOLocalJump(rightHendDefauldPos, 2.5f, 1, 0.4f));
            sequence.Join(CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(0, 0, 180), 0.4f, RotateMode.FastBeyond360)
                .SetDelay(0.5f)
                .OnComplete(() => CheckAnimadionEndLeft()));
            sequence.Join(CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(10, 0, 180), 0.4f, RotateMode.FastBeyond360));
            return;
        }
        sequence.Append(CardCountChange.cards[i].transform.DOLocalJump(rightHendDefauldPos, 2.5f, 1, 0.4f)
            .OnComplete(() => CardCountChange.cards[i].transform.DOPunchScale(new Vector3(.18f, 0, .18f), 0.2f)));
        sequence.Join(CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(0, 0, 180), 0.4f, RotateMode.FastBeyond360));
        sequence.Join(CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(10, 0, 180), 0.4f, RotateMode.FastBeyond360)
            .OnComplete(() => CardCountChange.cards[i].transform.DOLocalRotate(new Vector3(0, 0, 180), 0.1f, RotateMode.FastBeyond360)));




    }
    void CheckAnimadionEndRight()
    {

        JumpCard.isCountChange = true;
        CardCountChange.cardsRightHand = !CardCountChange.cardsRightHand;
        rightHendDefauldPos.y = 0;
        moveDelayLeft = true;
        repeatJumpLeft = false;
    }
    void CheckAnimadionEndLeft()
    {
        JumpCard.isCountChange = true;
        CardCountChange.cardsRightHand = !CardCountChange.cardsRightHand;
        leftHendDefauldPos.y = 0;
        moveDelayRight = true;
        repeatJumpRight = false;
    }
    public void JumpDirection(int direction)
    {

        StartCoroutine(SwichUpCards(direction));
    }
   
}
