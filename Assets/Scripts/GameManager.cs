using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallController ballController;

    public int jogadorScore = 0;
    public int enemyScore = 0;
    public TextMeshProUGUI textJogadorPoints;
    public TextMeshProUGUI textEnemyPoints;
    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;
    public int winPoints = 5;

    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        enemyPaddle.position = new Vector3(7f, 0f, 0f);
        ballController.ResetBall();
        jogadorScore = 0;
        enemyScore = 0;

        textEnemyPoints.text = enemyScore.ToString();
        textJogadorPoints.text = jogadorScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScoreJogador()
    {
        jogadorScore++;
        textJogadorPoints.text = jogadorScore.ToString();
        CheckWin();
    }
    
    public void ScoreEnemy()
    {
        enemyScore++;
        textEnemyPoints.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints)
        {
            EndGame();
        }
        if (jogadorScore >= winPoints)
        {
            EndGame();
        }
    }
    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(jogadorScore > enemyScore);
        textEndGame.text = "Vitória "+ winner;
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
