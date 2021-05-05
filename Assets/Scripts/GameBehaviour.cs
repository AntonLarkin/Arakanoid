using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour
{

    #region Variables

    public GameOverSequence gameOver;
    [SerializeField] private List<Blocks> blocks;
    [SerializeField] private Text scoreLabel;

    //private List<GameObject> defeatedBlocks = new List<GameObject>();

    #endregion


    #region Properties
    public int TotalScore { get; private set; }

    #endregion

    #region Unity lifecycle

    private void OnEnable()
    {
        Blocks.OnBlockDestroyed += Blocks_OnBlocksDestroyed;
    }



    private void Start()
    {
        scoreLabel.text = "0";
    }

    private void Update()
    {
        if (gameOver.ReadyToReload)
        {
            ReloadBlocks(blocks);
            gameOver.ReadyToReload = false;
            ReloadScore();
        }
    }

    #endregion


    #region Private methods

    private void ReloadScore()
    {
        TotalScore = 0;
        UpdateScoreLabel();
    }
    private void ReloadBlocks(List<Blocks> baseBlocks)
    {
        for (int i = 0; i < baseBlocks.Count; i++)
        {
            blocks[i].Reload();
        }
    }
    private void UpdateScoreLabel()
    {
        scoreLabel.text = TotalScore.ToString();
    }

    #endregion


    #region Public methods

    public void UpdateScore(int score)
    {
        TotalScore += score;
        UpdateScoreLabel();
    }


    #endregion

    #region Event handlers

    private void Blocks_OnBlocksDestroyed(GameObject block, int score)
    {
        //defeatedBlocks.Add(block);
        UpdateScore(score);
    }

    #endregion
}
