using UnityEngine;

public class DamageableObjects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Collider2D myCollider;
    [SerializeField] int hp;

    
    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            TakeDamage(collision.gameObject.GetComponent<Ball>().Damage);
        }
    }
    private void TakeDamage(int damage)
    {

    }
}
