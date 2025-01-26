using UnityEngine;

public class DamageableObjectVisual : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] SpriteRenderer damagedSpriteRender;
    [SerializeField] DamageableObjects damageableObject;
    [SerializeField] Sprite aLittleDamage;
    [SerializeField] Sprite aLotOfDamage;

    private void Awake()
    {
        damageableObject = this.GetComponentInParent<DamageableObjects>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
