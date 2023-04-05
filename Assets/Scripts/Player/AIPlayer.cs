using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public int currentPosition = 0;
    public int targetPosition = 10;

    public Dice dice;

    void Start()
    {

    }

    void Update()
    {
        Move(dice.GetResult());
    }

    public void Move(int steps)
    {
        currentPosition += steps;

        if (currentPosition >= targetPosition)
        {
            Debug.Log("Game Over!");
        }
    }
}