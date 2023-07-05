using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class MessageUpdater
{
    [SerializeField] TextMeshProUGUI m_Object;
    private Queue<string> messageHistory = new Queue<string>();
    public int maxMessages = 10;

    public void SetUpMessageUpdater(TextMeshProUGUI m_Object)
    {
        if (this.m_Object != null)
        {
            Debug.Log("You can't set another Channel");
            return;    
        }
        this.m_Object = m_Object;
    }

    private void UpdateMessage(TextMeshProUGUI m_Object, Queue<string> messageHistory)
    {
        string message = "";
        foreach (string msg in messageHistory)
        {
            message += msg + "\n";
        }
        m_Object.text = message;
    }

    public void AddMessage(string newMessage)
    {
        messageHistory.Enqueue(newMessage);
        if (messageHistory.Count > maxMessages)
        {
            messageHistory.Dequeue();
        }
        UpdateMessage(m_Object, messageHistory);
    }

    public void EditMessage(int index, string newMessage)
    {
        List<string> messageList = messageHistory.ToList();
        messageList[index] = newMessage;
        messageHistory = new Queue<string>(messageList);
        UpdateMessage(m_Object, messageHistory);
    }

    public void ClearHistory()
    {
        messageHistory.Clear();
        UpdateMessage(m_Object, messageHistory);
    }

    public void ScrollUp()
    {
        string oldestMessage = messageHistory.Dequeue();
        messageHistory.Enqueue(oldestMessage);
        UpdateMessage(m_Object, messageHistory);
    }

    public void ScrollDown()
    {
        string newestMessage = messageHistory.Dequeue();
        messageHistory.Enqueue(newestMessage);
        UpdateMessage(m_Object, messageHistory);
    }

    public void SetMaxMessages(int max)
    {
        this.maxMessages = max;
    }
}

