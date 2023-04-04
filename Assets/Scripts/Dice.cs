using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;

    private int result;
    private string[] messageHistory = new string[10];
    private int messageIndex = 0;

    public void Roll()
    {
        result = Random.Range(1, 7);
        messageHistory[messageIndex] = result.ToString();
        messageIndex = (messageIndex + 1) % 10;
        MessageUpdater.UpdateMessage(m_Object, messageHistory, messageIndex);
    }
}

public static class MessageUpdater
{
    public static void UpdateMessage(TextMeshProUGUI m_Object, string[] messageHistory, int messageIndex)
    {
        string message = messageHistory[messageIndex] + "\n";
        for (int i = 1; i < 10; i++)
        {
            if (messageHistory[(messageIndex + i) % 10] != null)
            {
                message += messageHistory[(messageIndex + i) % 10] + "\n";
            }
        }
        m_Object.text = message;
    }
}
