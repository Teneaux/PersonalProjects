using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private float size;
    [SerializeField] private Rigidbody2D ballRigidBody;

    private void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (ballRigidBody.linearVelocityX == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int GetDamageValue()
    {
        return Damage;
    }
}
