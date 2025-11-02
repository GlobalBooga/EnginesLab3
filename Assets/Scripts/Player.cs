using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    InputSystem_Actions actions;
    private Vector2 input;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public SpriteRenderer GetSpriteRenderer => sr;
    
    public float maxSpeed = 5;
    public float acceleration = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        actions = new InputSystem_Actions();
        actions.Player.Move.performed += ctx =>
        {
            input = ctx.ReadValue<Vector2>();
        };
        actions.Player.Move.canceled += ctx =>
        {
            input = Vector2.zero;
        };
        
        actions.Player.Move.Enable();
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        actions.Dispose();
    }

    private void Start()
    {
        EventBroadcaster.OnItemPickup += OnItemPickup;
    }

    private void OnItemPickup(IItemInterface obj)
    {
        obj?.ApplyEffectToPlayer(this);
        
    }

    // Update is called once per frame
    private void Update()
    {
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity + input * (Time.deltaTime * acceleration), maxSpeed);
    }
}
