using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    #region Variables

    [SerializeField] private int score;

    #endregion


    #region Properties

    public int Score => score;

    #endregion
}
