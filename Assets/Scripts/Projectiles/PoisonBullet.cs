using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : Projectile
{
    float progress = 0;

    void FixedUpdate()
    {
        if(targets.Count > 0)
        {
            if(targets[0] != null)
            {
                if(Vector3.Distance(transform.position, targets[0].transform.position) < 0.2f)
                {
                    targets[0].GetComponent<Enemy>().TakeContinuousDamage((int)damage, 5, 1);
                    Destroy(gameObject);
                }
                transform.position = Vector3.Lerp(tower.position, targets[0].transform.position, progress);

                progress += speed;
            }
            else Destroy(gameObject);
        }
        else Destroy(gameObject);
    }
}
