using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool isClick = false;
    public Rigidbody2D rb;
    public double clickTime =0;
    private void Update()
    {
        //Debug.Log(Input.mousePosition);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        move();
    }
    public void move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickTime = 0;
            isClick = true;
        }
        if(Input.GetMouseButtonUp(0))
            isClick = false;
        if (isClick)
        {
            clickTime += Time.deltaTime;
            if (clickTime >= 0.15)
            {
                if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
                {
                    rb.velocity = new Vector3(3, 0, 0);
                }
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
                {
                    rb.velocity = new Vector3(-3, 0, 0);
                }
                else 
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }
}
