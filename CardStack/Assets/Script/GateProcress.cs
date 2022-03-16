using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateProcress : MonoBehaviour
{
    [SerializeField] ScriptableOfGate procressNumber;
    [SerializeField] Text numberText;
    public int Count;
    private void Awake()
    {
        Count = procressNumber.Amound;
        if (Count < 0)
        {
            numberText.text =Count.ToString();
        }
        else
        {
             numberText.text = "+"+Count.ToString();
        }
        if (transform.position.x < 0)
        {
            gameObject.tag = "LeftGate";
        }
        else
        {
            
            gameObject.tag = "RightGate";
        }
    }


}
