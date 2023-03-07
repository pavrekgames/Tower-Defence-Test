using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerLives = 3;
    public static int money = 100;
    public static int enemiesAmount = 0;
    
    void Update()
    {
        if(playerLives <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
