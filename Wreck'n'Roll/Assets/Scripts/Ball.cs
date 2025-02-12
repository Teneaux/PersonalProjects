using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private float size;
    [SerializeField] private Rigidbody2D ballRigidBody;

    public event EventHandler OnBallDeath;


    private void Awake()
    {
        PointManager.Instance.AddABall(this);
    }
    private void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (ballRigidBody.linearVelocityX == 0)
        {
            OnBallDeath?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);            
        }
    }

    public int GetDamageValue()
    {
        return Damage;
    }
}
