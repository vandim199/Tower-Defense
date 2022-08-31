using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoE : Projectile
{
    void Start()
    {
        if(targets.Count > 0)
        {
            foreach(Enemy target in targets)
            {
                if(target == null) continue;
                
                target.GetComponent<Enemy>().TakeDamage((int)damage);
                Destroy(gameObject);
            }
        }
    }
}
