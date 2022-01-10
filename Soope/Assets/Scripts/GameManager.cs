using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
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

                break;
            case GameManagerState.Gameplay:

                playButton.SetActive(false);

                playerShip.GetComponent<PlayerControl>().init();
                break;
            case GameManagerState.Gameover:

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
}
