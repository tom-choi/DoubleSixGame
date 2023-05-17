using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour
{
    private int result;
    public int minValue = 1;
    public int maxValue = 7;

    [SerializeField] MessageUpdater console_messageUpdater = new MessageUpdater();
    [SerializeField] TextMeshProUGUI console_channel;

    private void Awake() 
    {
        if (console_messageUpdater != null) 
        {
            console_messageUpdater.SetUpMessageUpdater(console_channel);
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
        if (console_messageUpdater != null) 
        {
            console_messageUpdater.AddMessage(playerName + " roll " + result.ToString() + " !");
        }
        return result;
    }
    public int GetResult()
    {
        return result;
    }
}