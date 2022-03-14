using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCountChange : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] GameObject rightHend;
    [SerializeField] GameObject lesftHend;
    List<GameObject> carts = new List<GameObject>();

    Vector3 leftHendDefauldPos;
   
    void Start()
    {
        leftHendDefauldPos = lesftHend.transform.localPosition;
        leftHendDefauldPos.y = 2.2f;
        for (int i = 0; i < 10; i++)
        {
            leftHendDefauldPos.y += 0.15f;
            GameObject newCard = Instantiate(card, leftHendDefauldPos, Quaternion.identity);
            newCard.transform.SetParent(transform);
            carts.Add(newCard);

        }
    }

   
  
}
