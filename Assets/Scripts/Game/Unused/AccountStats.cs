using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountStats : MonoBehaviour
{
    private int money;

    public int Money
    {
        get { return money; }
        set { money = value; }
    }
    private int games;

    public int Games
    {
        get { return games; }
        set { games = value; }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
