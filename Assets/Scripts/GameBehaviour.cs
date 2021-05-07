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

    private LevelManager levelManager;

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
        levelManager = FindObjectOfType<LevelManager>();
        ReloadScore();
    }

    private void Update()
    {
        if (gameOver.ReadyToReload)
        {
            ReloadBlocks(blocks);
            gameOver.ReadyToReload = false;
            levelManager.SetBlocksquantity();
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
        UpdateScore(score);
    }

    #endregion
}
