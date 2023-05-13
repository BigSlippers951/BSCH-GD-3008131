using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public int score;

    void Start()
    {
        print(score);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EndPoint")
        {
            score++;
            print(score);
        }
    }
}
