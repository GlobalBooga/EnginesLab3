using System;
using System.Collections;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IItemInterface
{
    public float duration = 2;
    
    protected SpriteRenderer spriteRenderer;
    protected BoxCollider2D boxCollider2D;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void ApplyEffectToPlayer(Player player)
    {
        StartCoroutine(ApplyEffectCoroutine(player));
    }

    protected virtual IEnumerator ApplyEffectCoroutine(Player player)
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        yield return new WaitForSeconds(duration);
        
        Destroy(gameObject);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        EventBroadcaster.OnItemPickup.Invoke(this);
    }
}
