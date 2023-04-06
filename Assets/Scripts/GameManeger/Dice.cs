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

    private void Awake() {
        if (messageUpdater != null) 
        {
            messageUpdater.SetUpMessageUpdater(channel);
        }
    }
    public void Roll()
    {
        result = Random.Range(minValue, maxValue);
        if (messageUpdater != null) 
        {
            messageUpdater.AddMessage(result.ToString());
        }
    }

    public int GetResult()
    {
        return result;
    }
}