using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private Pin[] pins;

    private bool isGamePlaying = false;
    // Start is called before the first frame update

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        isGamePlaying = true;
        
        player.StartThrow();
    }

    public void SetNextThrow()
    {
        Invoke("NextThrow", 3.0f);
    }

    private void NextThrow()
    {
        if (scoreManager.currentFrame == 0)
        {
            Debug.Log($"Game Over! Score is:{scoreManager.CalculateTotalScore()}");
        }
        else
        {
            Debug.Log($"Frame is: {scoreManager.currentFrame}. Throw is {scoreManager.currentThrow}");
            scoreManager.SetFrameScore(CalculateFallenPins());

            Debug.Log($"Current score is: {scoreManager.CalculateTotalScore()}");
            player.StartThrow();
        }
    }

    public void ResetAllPins()
    { foreach (Pin pin in pins)

        {
            pin.ResetPin();
        }
    }

    public int CalculateFallenPins()
    {
        int count = 0;
        foreach(Pin pin in pins)
        {
            if (pin.isFallen)
                count++;
            pin.gameObject.SetActive(false);
        }
        Debug.Log($"Total fallen Pins {count}");
        return count;
    }
}
