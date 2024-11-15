using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrejectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject player;
    private Transform Transform;
    private Rigidbody2D rb;
    //public GameObject destroyEffect;
    private void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 difference = (player.transform.position - transform.position).normalized;
        rb.velocity = difference * speed;

    }
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    private void Update()
    {

    }
    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
