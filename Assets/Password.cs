using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    public TMP_Text password;
    public string realPassword;
    public int number;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.SetActive(false);
        }
    }
    public void StartPassword()
    {
        gameObject.SetActive(true);
    }
    public void PasswordBack()
    {
        if (password != null)
        {
            if( int.TryParse(password.text,out number))
            {
                number = number / 10;
                if(number !=0)
                {
                    password.text = number.ToString();
                }
                else
                {
                    password.text = null;
                }
            }
        }
    }
    public void PasswordCheck()
    {
        if (password.text == realPassword)
        {
            gameObject.SetActive(false);
        }
        else
        {
            password.text = null;
        }
    }
    public void PasswordInput0()
    {
        password.text = password.text + "0";
    }
    public void PasswordInput1()
    {
        password.text = password.text+"1";
    }
    public void PasswordInput2()
    {
        password.text = password.text + "2";
    }
    public void PasswordInput3()
    {
        password.text = password.text + "3";
    }
    public void PasswordInput4()
    {
        password.text = password.text + "4";
    }
    public void PasswordInput5()
    {
        password.text = password.text + "5";
    }
    public void PasswordInput6()
    {
        password.text = password.text + "6";

    }
    public void PasswordInput7()
    {
        password.text = password.text + "7";
    }
    public void PasswordInput8()
    {
        password.text = password.text + "8";
    }
    public void PasswordInput9()
    {
        password.text = password.text + "9";
    }
}
