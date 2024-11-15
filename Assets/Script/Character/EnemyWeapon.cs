using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShorts;
    public float startTimeBtwLongs;
    private void Update()
    {
        //计算距离
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //计算角度
        float rotZ = Mathf.Atan2(difference.y, difference.x)*Mathf.Rad2Deg;
        //转向
        transform.rotation = Quaternion.Euler(0f,0f,rotZ + offset);
        if (timeBtwShorts <= 0 )
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShorts = startTimeBtwLongs;
            }
        }
        else
        {
            timeBtwShorts -= Time.deltaTime;
        }
    }
}
