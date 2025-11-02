using System;
using System.Collections;
using UnityEngine;

public class SpeedBoost : ItemBase
{
    public float boost = 5;
    public float accelerationBoost = 50;

    protected override IEnumerator ApplyEffectCoroutine(Player player)
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        player.maxSpeed += boost;
        player.acceleration += accelerationBoost;
        
        yield return new WaitForSeconds(duration);
        
        player.maxSpeed -= boost;
        player.acceleration -= accelerationBoost;
        
        Destroy(gameObject);
    }
}
