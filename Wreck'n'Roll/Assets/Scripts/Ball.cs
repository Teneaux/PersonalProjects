using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private float size;
    [SerializeField] private Rigidbody2D ballRigidBody;
    
    public int GetDamageValue()
    {
        return Damage;
    }
}
