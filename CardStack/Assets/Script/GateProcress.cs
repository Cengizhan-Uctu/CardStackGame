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
        numberText.text = procressNumber.Amound.ToString();
    }


}
