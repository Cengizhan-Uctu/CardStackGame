using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingeltonGenerik<GameManager>
{
     
    #region singelton
    private void Awake()
    {
        MakeSingelton(this);
    }
    #endregion
    public event System.Action OnGameOver;
    public event System.Action OnWin;

    public void GameOver()
    {
        //if (OnGameOver != null) 
        //{
        //    OnGameOver();
        //}

        // Kisa Yazim
        OnGameOver?.Invoke();
    }
    public void GameWin()
    {
        OnWin?.Invoke();
    }
}