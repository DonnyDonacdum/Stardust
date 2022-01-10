using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGo;
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        Gameover
    }
    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.Opening;
    }


    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                playButton.SetActive(false);

                playerShip.GetComponent<PlayerControl>().init();

                enemySpawner.GetComponent<EnemySpawnerGO>().ScheduleEnemySpawner();
                break;
            case GameManagerState.Gameover:
                enemySpawner.GetComponent<EnemySpawnerGO>().UnscheduleEnemySpawner();

                Invoke("ChangeOpening",8f);

                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState ();
    }

    public void StartGameplay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeOpening()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
