using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform player;
    public Transform shotPoint;
    private float timeBtwShorts;
    public float startTimeBtwLongs;
    private void Update()
    {
        //计算距离
        Vector3 distance = player.position - transform.position;
        float realDistance = Mathf.Sqrt((distance.x* distance.x+ distance.y+ distance.y));
        //计算角度
        float rotZ = Mathf.Atan2(distance.y, distance.x)*Mathf.Rad2Deg;
        //转向
        transform.rotation = Quaternion.Euler(0f,0f,rotZ + offset);
        if (realDistance<=10&& timeBtwShorts <= 0)
        {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShorts = startTimeBtwLongs;
        }
        else
        {
            timeBtwShorts -= Time.deltaTime;
        }
    }
}
