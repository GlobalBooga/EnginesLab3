using System;
using System.Collections;
using UnityEngine;

public class SizeBoost : ItemBase
{
    public float boost = 2;

    protected override IEnumerator ApplyEffectCoroutine(Player player)
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        player.transform.localScale += new Vector3(boost, boost, boost);
        
        yield return new WaitForSeconds(duration);
        
        player.transform.localScale -= new Vector3(boost, boost, boost);
        
        Destroy(gameObject);
    }
}
