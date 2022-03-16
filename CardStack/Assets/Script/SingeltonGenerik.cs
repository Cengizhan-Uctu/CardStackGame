using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingeltonGenerik<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }
    protected void MakeSingelton(T entity)
    {
        if (Instance == null)
        {
            Instance = entity;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}