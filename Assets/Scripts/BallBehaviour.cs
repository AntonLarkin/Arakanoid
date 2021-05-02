using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private GameObject padTransform;

    private bool isLaunched;


    #endregion

    #region Unity lifecycle

    private void Update()
    {
        if (!isLaunched)
        {
            Vector3 padPosition = padTransform.transform.position;
            padPosition.y = transform.position.y;

            transform.position = padPosition;

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
        Vector2 force = direction * speed;
        rb.AddForce(force);
        isLaunched = true;
    }

    #endregion
}
