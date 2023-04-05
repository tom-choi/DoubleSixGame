using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text resultText; // 显示骰子点数的文本框
    public Animator diceAnimator; // 骰子的Animator组件
    public int currentPlayer = 0; // 当前玩家的编号
    public GameObject[] players; // 所有玩家
    public int[] playerPositions; // 所有玩家的位置
    public int maxPlayerCount = 4; // 最大玩家数
    public bool gameOver = false; // 游戏是否结束
    public Dice dice;

    // 初始化玩家位置，设置玩家编号，开始游戏
    // void Start()
    // {
    //     playerPositions = new int[maxPlayerCount];

    //     for (int i = 0; i < maxPlayerCount; i++)
    //     {
    //         playerPositions[i] = 0;
    //     }

    //     StartCoroutine(GameLoop());
    // }

    // 游戏主循环，不断切换当前玩家，等待玩家投掷骰子，更新玩家位置
    // IEnumerator GameLoop()
    // {
    //     while (!gameOver)
    //     {
    //         // 等待当前玩家投骰子
    //         yield return StartCoroutine(WaitForPlayerToRollDice());

    //         // 根据骰子点数更新玩家位置
    //         playerPositions[currentPlayer] += dice.Roll();

    //         // 如果玩家移动到了终点，游戏结束
    //         if (playerPositions[currentPlayer] >= 10)
    //         {
    //             gameOver = true;
    //             resultText.text = "游戏结束，玩家" + (currentPlayer + 1) + "获胜！";
    //             yield break;
    //         }

    //         // 切换到下一个玩家
    //         currentPlayer = (currentPlayer + 1) % maxPlayerCount;
    //     }
    // }

    // 等待当前玩家投骰子
    // IEnumerator WaitForPlayerToRollDice()
    // {
    //     // 获取当前玩家控制器组件
    //     PlayerController playerController = players[currentPlayer].GetComponent<PlayerController>();

    //     // 等待玩家投骰子
    //     yield return StartCoroutine(playerController.WaitForRollDice());

    //     // 播放骰子动画，并更新骰子点数显示
    //     // int diceNumber = dice.Roll();
    //     // resultText.text = "玩家" + (currentPlayer + 1) + "投掷了" + diceNumber + "点";
    //     // diceAnimator.SetInteger("diceNumber", diceNumber);
    //     // yield return new WaitForSeconds(1f);
    //     // diceAnimator.SetInteger("diceNumber", 0);
    // }
}
