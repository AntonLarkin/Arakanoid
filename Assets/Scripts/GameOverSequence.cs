using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSequence : MonoBehaviour
{
    #region Variables

    public BallBehaviour ballBehaviour;
    private bool isReadyToReload;

    #endregion


    #region Properties

    public bool ReadyToReload { get; set; }

    #endregion


    #region Unity lifecycles

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ReadyToReload = true;
        ballBehaviour.IsLaunched = false;
        ballBehaviour.UpdateBallPosition();
    }

    #endregion
}
