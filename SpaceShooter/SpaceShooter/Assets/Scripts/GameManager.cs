using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject gameOver;
    public GameObject scoreText;
    public GameObject timeText;
    public GameObject gameTitle;

    public enum ManagerState
    {
        Opening,
        GamePlay,
        GameOver,
    }

    ManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = ManagerState.Opening;
    }

    // Update is called once per frame
    public void UpdateManagerState()
    {
        switch (GMState)
        {
            case ManagerState.Opening:

                playButton.SetActive(true);

                gameTitle.SetActive(true);

                gameOver.SetActive(false);

                break;

            case ManagerState.GamePlay:

                scoreText.GetComponent<PlayerScore>().Score = 0;

                playButton.SetActive(false);

                gameTitle.SetActive(false);

                playerShip.GetComponent<Player>().Init();

                enemySpawner.GetComponent<EnemySpawn>().StartEnemySpawn();

                timeText.GetComponent<TimeCounter>().StartTimeCounter();

                break;

            case ManagerState.GameOver:

                timeText.GetComponent<TimeCounter>().StopTimeCounter();

                enemySpawner.GetComponent<EnemySpawn>().StopEnemySpawn();

                gameOver.SetActive(true);

                Invoke("ChangeToOpeningState", 8f);

                break;
        }
    }

    public void SetManagerState(ManagerState state)
    {
        GMState = state;
        UpdateManagerState();
    }

    public void StartGame()
    {
        GMState = ManagerState.GamePlay;
        UpdateManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetManagerState(ManagerState.Opening);
    }
}
