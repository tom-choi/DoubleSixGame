using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour
{
    private int result;
    public int minValue = 1;
    public int maxValue = 7;

    [SerializeField] MessageUpdater messageUpdater = new MessageUpdater();
    [SerializeField] TextMeshProUGUI channel;

    private void Awake() 
    {
        if (messageUpdater != null) 
        {
            messageUpdater.SetUpMessageUpdater(channel);
        }
    }
    public int Roll()
    {
        result = Random.Range(minValue, maxValue);
        return result;
    }
    public int PlayerRoll(string playerName)
    {
        int tmp = Roll();
        if (messageUpdater != null) 
        {
            messageUpdater.AddMessage(playerName + " roll " + result.ToString() + " !");
        }
        return result;
    }

    public int GetResult()
    {
        return result;
    }
}