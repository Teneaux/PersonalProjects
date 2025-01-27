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

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(damageableObject.HPPercentage());
        
        if( damageableObject.HPPercentage() <= .2f)
        {
            damagedSpriteRender.sprite = aLotOfDamage;
        }
        else if (damageableObject.HPPercentage() <= .7f)
        {
            damagedSpriteRender.sprite = aLittleDamage;
        }
    }
}
