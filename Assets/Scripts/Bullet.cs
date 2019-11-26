using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

    private void Update() {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2.0f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }

    public void FindTarget(Transform target)
    {
        this.target = target;
    }
}
