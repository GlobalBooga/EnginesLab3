## EnginesLab3
 
Alexandre Anastasakis - 100892202

#### Project name: Triangulicious
This is an ultra basic game where you control a triangle and you collect circles. Collecting circles apply different effects to the triangle.

#### How the observer pattern was used

I took inspiration from radio towers when making this code.
```
// singleton
public class EventBroadcaster : Monobehaviour
{

  public static Action<IItemInterface> OnItemPickup;

  Awake
  {
    // make sure this is the only object of this type
  }
}

```

Listeners can just:
```
public class ItemSpawner : MonoBehaviour
{
    private void Start()
    {
        EventBroadcaster.OnItemPickup += OnItemPickup;
    }
}

public class Player : MonoBehaviour
{
    private void Start()
    {
        EventBroadcaster.OnItemPickup += OnItemPickup;
    }
}
```

I chose this method because it is very scalable. Items can vary and can derive from other items, so its nice to have the event in one place.
From any item, we can simply call:
```
void SomeFunction()
{
   EventBroadcaster.OnItemPickup.Invoke(this);
}
```

However, since we have many items, I implemented a base item that will handle the call to the event
```
public abstract class ItemBase : MonoBehaviour, IItemInterface
{
    /* 
     * base item stuff
     */

    private void OnTriggerEnter2D(Collider2D other)
    {
        EventBroadcaster.OnItemPickup.Invoke(this);
    }
}
```

#### Reflection

**What element of your game adopts the chosen pattern?**
- Trigger events. Items notify observers when a trigger event fires. In this case, when the player moves over an item.

**Why is this pattern a good choice for spawning these objects?**
- We never know when a trigger event will happen and we don't care about the items themselves (we don't want to keep a cached reference to each item) because the items have a short lifespan and they vary in type. Using a central event broadcaster to relay a message from a random item makes a natural and simple solution to this problem.
