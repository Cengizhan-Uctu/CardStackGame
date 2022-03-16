using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCountChange : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] GameObject rightHend;
    [SerializeField] GameObject lesftHend;
    public static List<GameObject> cards = new List<GameObject>();
    public static bool cardsRightHand;
    Vector3 leftHendDefauldPos;
    Vector3 rightHendDefauldPos;
    float totalHight;

    private void Awake()
    {
        cardsRightHand = true;
        cards.Clear();
        leftHendDefauldPos = lesftHend.transform.position;
        rightHendDefauldPos = rightHend.transform.localPosition;
        leftHendDefauldPos.y = 2.2f;
        totalHight = 0;
        totalHight = leftHendDefauldPos.y;
        CardİncreaseLeft(10);
    }
  
    public void CardİncreaseLeft(int amount)
    {

        for (int i = 0; i < amount; i++)
        {
            leftHendDefauldPos.z = transform.position.z;
            totalHight+= 0.15f;
            leftHendDefauldPos.y = totalHight;
            GameObject newCard = Instantiate(card, leftHendDefauldPos,Quaternion.identity);
            newCard.transform.SetParent(transform);
            CardCountChange.cards.Add(newCard);

        }
    }
    public void CardİncreaseRight(int amount)
    {

        for (int i = 0; i < amount; i++)
        {
            rightHendDefauldPos.z = transform.position.z;
            totalHight += 0.15f;
            rightHendDefauldPos.y =totalHight;
            GameObject newCard = Instantiate(card, rightHendDefauldPos, Quaternion.Euler(new Vector3(0, 0, 180)));
            newCard.transform.SetParent(transform);
            CardCountChange.cards.Insert(0,newCard);

        }
    }
    public void CardDecreaseLeft(int amount)
    {

        amount *= -1;
        if (CardCountChange.cardsRightHand)
        {
            for (int i = 0; i < amount; i++)
            {
                if (CardCountChange.cards.Count > 0)
                {
                    totalHight -= 0.15f;
                    Destroy(CardCountChange.cards[cards.Count - 1]);
                    CardCountChange.cards.RemoveAt(cards.Count - 1);
                    if (cards.Count < 1)
                    {
                        Debug.Log("gameover");
                    }
                }
                

            }
        }
        else
        {
            for (int i = 0; i < amount; i++)
            {
                if (cards.Count > 0)
                {
                    totalHight -= 0.15f;
                    Destroy(CardCountChange.cards[0]);
                    CardCountChange.cards.RemoveAt(0);
                    if (CardCountChange.cards.Count < 1)
                    {
                        Debug.Log("gameover");// game over events
                    }
                }
               

            }
        }

    }
    public void CardDecreaseRight(int amount)
    {
        amount *= -1;
        if (!CardCountChange.cardsRightHand)
        {
            for (int i = 0; i < amount; i++)
            {
               
                if (cards.Count > 0)
                {
                    totalHight -= 0.15f;
                    Destroy(CardCountChange.cards[0]);
                    CardCountChange.cards.RemoveAt(0);
                    Debug.Log(CardCountChange.cards.Count);
                }
                else if (CardCountChange.cards.Count < 1)
                {
                    Debug.Log("gameover");
                }


            }
        }
        else
        {
            for (int i = 0; i < amount; i++)
            {

                if (cards.Count > 0)
                {
                    totalHight -= 0.15f;
                    Destroy(CardCountChange.cards[cards.Count - 1]);
                    CardCountChange.cards.RemoveAt(cards.Count - 1);
                }


            }
        }

    }




    private void OnTriggerEnter(Collider other)
    {

        int otherCount = other.GetComponent<GateProcress>().Count;
        if (otherCount <= 0)
        {
            if (other.CompareTag("LeftGate") && !CardCountChange.cardsRightHand)
            {
                Debug.Log("1");
                CardDecreaseLeft(otherCount);
            }
            if (other.CompareTag("RightGate") && CardCountChange.cardsRightHand)
            {
                Debug.Log("2");
                CardDecreaseRight(otherCount);
               
            }
        }
        else
        {
            if (other.CompareTag("LeftGate") && !CardCountChange.cardsRightHand)
            {
                Debug.Log("3");
                CardİncreaseRight(otherCount);
            }
            if (other.CompareTag("RightGate") && CardCountChange.cardsRightHand)
            {
                Debug.Log("4");
                CardİncreaseLeft(otherCount);
            }
        }


    }

}
