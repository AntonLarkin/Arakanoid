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
    [SerializeField] private float minValueX;
    [SerializeField] private float maxValueX;
    [SerializeField] private float minValueY;
    [SerializeField] private float maxValueY;

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
            UpdateBallPosition();

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
        Vector2 direction = GetRandomDirection();
        Vector2 force = direction * speed;
        rb.AddForce(force);
        IsLaunched = true;
    }

    private Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(minValueX, maxValueX), Random.Range(minValueY, maxValueY)).normalized;
    }

    #endregion


    #region Public methods

    public void UpdateBallPosition()
    {
        Vector3 padPosition = padTransform.transform.position;
        padPosition.y = startPositionY;
        transform.position = padPosition;
    }

    #endregion

}
