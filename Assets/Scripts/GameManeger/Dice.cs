using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    private int result;
    public int minValue = 1;
    public int maxValue = 7;

    public MessageUpdater messageUpdater;

    public void Roll()
    {
        result = Random.Range(minValue, maxValue);
        messageUpdater.AddMessage(result.ToString());
    }

    public int GetResult()
    {
        return result;
    }
}