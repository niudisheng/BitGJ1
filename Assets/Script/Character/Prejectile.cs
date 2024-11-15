using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prejectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private Transform Transform;
    private Rigidbody2D rb;
    //public GameObject destroyEffect;
    private void Awake()
    {
        Vector3 difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = difference*speed;
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
