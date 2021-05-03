using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    #region Variables

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject padTransform;
    [SerializeField] private float startPositionY;

    private Vector2 direction;
    private bool isLaunched;

    #endregion


    #region Properties

    public bool IsLaunched { get; set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {

        if (!IsLaunched)
        {
            BallPosition();

            if (Input.GetMouseButtonDown(0))
            {

                LaunchBall();
            }

        }

    }

    #endregion


    #region Private methods

    private void LaunchBall()
    {
        SetDirection();
        Vector2 force = direction * speed;
        rb.AddForce(force);
        IsLaunched = true;
    }

    private void SetDirection()
    {
        direction = new Vector2(Random.Range(-3, 3), Random.Range(3, 5));
    }

    #endregion


    #region Public methods

    public void BallPosition()
    {

        Vector3 padPosition = padTransform.transform.position;
        padPosition.y = startPositionY;
        transform.position = padPosition;
    }

    #endregion

}
