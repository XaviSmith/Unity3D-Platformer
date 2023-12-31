using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] Collider _collider;
    [SerializeField] Health healthObj;

    [SerializeField] float damageCooldown;

    [Header("Debug Settings")]
    [SerializeField] bool drawHurtbox = true;
    [SerializeField] Color32 inactiveColor;
    [SerializeField] Color32 activeColor;
    [SerializeField] Color32 collidingColor;
    ColliderState colliderState = ColliderState.ACTIVE;

    CountdownTimer damageTimer;

    private void Awake()
    {
        damageTimer = new CountdownTimer(damageCooldown);

        damageTimer.OnTimerStart += () => { colliderState = ColliderState.INACTIVE; };
        damageTimer.OnTimerStop += () => { colliderState = ColliderState.ACTIVE; };
    }

    void Update()
    {
        damageTimer.Tick(Time.deltaTime);
    }

    public void GetHit(int damage)
    {
        if(!damageTimer.IsRunning)
        {
            //Debug.Log(healthObj.transform.name + " GOT HIT");
            damageTimer.Start();
            healthObj.TakeDamage(damage);
        }
        
    }

    public void GetSquashed(int damage)
    {
        if (!damageTimer.IsRunning)
        {
            //Debug.Log(healthObj.transform.name + " GOT HIT");
            damageTimer.Start();
            healthObj.SquashDamage(damage);
        }

    }

    void OnDrawGizmos()
    {
        if(drawHurtbox)
        {
            switch (colliderState)
            {
                case ColliderState.INACTIVE:
                    Gizmos.color = inactiveColor;
                    break;
                case ColliderState.ACTIVE:
                    Gizmos.color = activeColor;
                    break;
                case ColliderState.COLLIDING:
                    Gizmos.color = collidingColor;
                    break;

            }
            Gizmos.DrawWireCube(_collider.bounds.center, _collider.bounds.size);
        }
        
    }


}
