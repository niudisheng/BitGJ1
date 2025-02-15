using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberItem : NPCInteractor
{
    public Password Password;
    public int number;
    private void Awake()
    {
        base.Awake();
        if(number == 1)
        {
            OnClick += OnInteract1;
        }
        if(number == 2)
        {
            OnClick += OnInteract2;
        }
        if(number == 3)
        {
            OnClick += OnInteract3;
        }
        if (number == 4)
        {
            OnClick += OnInteract4;
        }
        if (number == 5)
        {
            OnClick += OnInteract5;
        }
        if (number == 6)
        {
            OnClick += OnInteract6;
        }
        if (number == 7)
        {
            OnClick += OnInteract7;
        }
        if (number == 8)
        {
            OnClick += OnInteract8;
        }
        if( number == 9)
        {
            OnClick += OnInteract9;
        }
    }
    public virtual void OnInteract1()
    {
        Password.PasswordInput1();
    }
    public virtual void OnInteract2()
    {
        Password.PasswordInput2();
    }
    public virtual void OnInteract3()
    {
        Password.PasswordInput3();
    }
    public virtual void OnInteract4()
    {
        Password.PasswordInput4();
    }
    public virtual void OnInteract5()
    {
        Password.PasswordInput5();
    }
    public virtual void OnInteract6()
    {
        Password.PasswordInput6();
    }
    public virtual void OnInteract7()
    {
        Password.PasswordInput7();
    }
    public virtual void OnInteract8()
    {
        Password.PasswordInput8();
    }
    public virtual void OnInteract9()
    {
        Password.PasswordInput9();
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = originalScale * 1.0f;

    }

}
