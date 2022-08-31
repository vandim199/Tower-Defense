using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform tower;
    public List<Enemy> targets;
    public float speed;
    public float damage;

    public void SetParameters(Transform startPoint, List<Enemy> endPoint, float travelTime, float pDamage)
    {
        tower = startPoint;
        targets = endPoint;
        speed = travelTime;
        damage = pDamage;

        transform.position = tower.transform.position;
    }
}
