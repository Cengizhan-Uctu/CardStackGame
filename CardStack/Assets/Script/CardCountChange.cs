using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCountChange : MonoBehaviour
{
    public static List<GameObject> cards = new List<GameObject>();
    [SerializeField] GameObject card;
    [SerializeField] GameObject rightHend;
    [SerializeField] GameObject lesftHend;
    Vector3 leftHendDefauldPos;
    Vector3 rightHendDefauldPos;
    float totalHight;
    public static bool cardsRightHand;
    //public bool isOncolliderStay;
    public static bool isOntrigerStay;


    private void Awake()
    {
        isOntrigerStay = true;
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
       
        totalHight -=0.0241f;
        for (int i = 0; i < amount; i++)
        {
            leftHendDefauldPos.z = transform.position.z;
            totalHight+= 0.15f;
            leftHendDefauldPos.y = totalHight;
            GameObject newCard = Instantiate(card, leftHendDefauldPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            newCard.transform.SetParent(transform);
            CardCountChange.cards.Add(newCard);
           

        }
    }
    public void CardİncreaseRight(int amount)
    {
       
        totalHight -= 0.0241f;
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
                        GameManager.Instance.GameOver();
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
                        GameManager.Instance.GameOver();
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
                    if (CardCountChange.cards.Count < 1)
                    {
                        GameManager.Instance.GameOver();
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
                    Destroy(CardCountChange.cards[cards.Count - 1]);
                    CardCountChange.cards.RemoveAt(cards.Count - 1);
                    if (CardCountChange.cards.Count < 1)
                    {
                        GameManager.Instance.GameOver();
                    }
                }


            }
        }

    }




    
    private void OnTriggerStay(Collider other)
    {
        if (isOntrigerStay == true)
        {
           
            if (other.CompareTag("FinishLine"))
            {
                GameManager.Instance.GameWin();
                return;
            }

            int otherCount = other.GetComponent<GateProcress>().Count;
            if (JumpCard.isCountChange&&CardCountChange.isOntrigerStay)
            {
                if (otherCount <= 0)
                {
                    
                    if (other.CompareTag("LeftGate") && !CardCountChange.cardsRightHand)
                    {
                        CardCountChange.isOntrigerStay = false;
                        CardDecreaseLeft(otherCount);
                    }
                    if (other.CompareTag("RightGate") && CardCountChange.cardsRightHand)
                    {
                        CardCountChange.isOntrigerStay = false;
                        CardDecreaseRight(otherCount);

                    }
                    
                }
                else
                {
                   
                    if (other.CompareTag("LeftGate") && !CardCountChange.cardsRightHand)
                    {
                        CardCountChange.isOntrigerStay = false;
                        CardİncreaseRight(otherCount);
                    }
                    if (other.CompareTag("RightGate") && CardCountChange.cardsRightHand)
                    {
                        CardCountChange.isOntrigerStay = false;
                        CardİncreaseLeft(otherCount);
                    }
                    
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CardCountChange.isOntrigerStay = true;
    }
}
