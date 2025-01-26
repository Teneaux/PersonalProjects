using UnityEngine;

public class DamageableObjects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;

    
    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
        hp = maxHp;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
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
        hp -= damage;
    }

    public float HPPercentage()
    {
        float currentHpPercent = hp / maxHp;
        return currentHpPercent;
    }
}
