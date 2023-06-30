using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    private int totalScore;

    public int currentFrame
    {
        get;
        private set;  
    }

    public int currentThrow
    {
        get;
        private set;
    }

    private int[] frames = new int[10];
    private int[] ballScores = new int[3];

    private bool isSpare = false;
    private bool isStrike = false;

    void Start()
    {
        totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;

    }

    public void SetFrameScore(int score)
    {
        // check if the current throw is 1, ball 1 
        if (currentThrow == 1)
        {
            frames[currentFrame - 1] += score;

            if (isSpare)
            {
                frames[currentFrame - 2] += score;
                isSpare = false;
            }

            if (score == 10)
            {
                if (currentFrame == 10)
                {

                    //move to the the next frame since we've gotten full marks
                    currentThrow++;
                }
                else
                {
                    isStrike = true;
                    currentFrame++;
                }

                gameManager.ResetAllPins();
            }
            else
            {
                currentThrow++;
            }

            return;
        }
        

        //ball 2
        if (currentThrow == 2)
        {
            frames[currentFrame - 1] += score;

            if (isStrike)
            {
                frames[currentFrame - 2] += frames[currentFrame - 1];
                isStrike = false;
            }
            if (frames[currentFrame - 1] == 10)
            {
                //wait for ball 3
                if (currentFrame == 10)
                {
                    currentThrow++;
                }
                else
                {
                    isSpare = true;
                    // move to the next frame
                    currentFrame++;
                    //reset the throws to 0
                    currentThrow = 1;
                }
            }
            else
            {
                if (currentFrame == 10)
                {
                    currentFrame = 0;
                    currentThrow = 0;
                }
                else
                {
                    currentFrame++;
                    currentThrow = 1;
                }
            }
            gameManager.ResetAllPins();


            return;
        }
        if (currentThrow == 3 && currentFrame == 10)

        {
            frames[currentFrame - 1] += score;

            //endAll the throws
            currentThrow = 0;
            currentFrame = 0;

            return;

        }
        //ball 3
        if(currentThrow == 3 && currentFrame == 10)
            frames[currentFrame - 1] += score;
        //end all the throws
        currentThrow = 0;
        currentFrame = 0;
        return;
    }


    //

    public int CalculateTotalScore()
    {
        totalScore = 0;
        foreach (var item in frames)
        {
            totalScore += item;
        }
        return totalScore;

    }

    private void ResetScore()
    {
        totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;
        frames = new int[10];

    }
}
    
    


