using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dice : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
    public Animator animator;

    private int result;

    public void Roll()
    {
        result = Random.Range(1, 7);
        m_Object.text = result.ToString();
        animator.SetInteger("Result", result);
    }
}
