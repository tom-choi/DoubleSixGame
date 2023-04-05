using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MessageUpdater
{
    [SerializeField] TextMeshProUGUI m_Object;
    private string[] messageHistory = new string[10];
    private int messageIndex = 0;

    public void UpdateMessage(TextMeshProUGUI m_Object, string[] messageHistory, int messageIndex)
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
    public void AddMessage(string newMessage)
    {
        messageHistory[messageIndex] = newMessage;
        messageIndex = (messageIndex + 1) % 10;
        UpdateMessage(m_Object, messageHistory, messageIndex);
    }
}
