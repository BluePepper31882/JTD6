using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 500;

    public static int rounds;

    public static int Lives;
    public int startLives = 20;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        rounds = 0;
    }

}
