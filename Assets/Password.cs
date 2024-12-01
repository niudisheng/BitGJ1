using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;

public class Password : MonoBehaviour
{
    public DoubleSO progress;
    public int currentIndex = 0;
    public SpriteRenderer SpriteRenderer;
    public Sprite PasswordImageBefore;
    public Sprite PasswordImageAfter;
    public List<Sprite> number = new List<Sprite>();
    public List<GameObject> inputNumber = new List<GameObject>();
    public List<SpriteRenderer> inputNumberSprite = new List<SpriteRenderer>();
    public List<Sprite> realNumber = new List<Sprite>();
    public BoolSO isNotLock;
    private void Awake()
    {
        SpriteRenderer.sprite = PasswordImageBefore;
        foreach (var item in inputNumber)
        {
            SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
            inputNumberSprite.Add(spriteRenderer);
        }
    }
    public void StartPassword()
    {
        gameObject.SetActive(true);
    }
    private void Update()
    {

        if (currentIndex == 4)
           PasswordCheck();
    }
    public void PasswordCheck()
    {
        if (inputNumberSprite[0].sprite == realNumber[0])
        {
            if (inputNumberSprite[1].sprite == realNumber[1])
            {
                if (inputNumberSprite[2].sprite == realNumber[2])
                {
                    if (inputNumberSprite[3].sprite == realNumber[3])
                    {
                        SpriteRenderer.sprite = PasswordImageAfter;
                        Debug.Log("win");
                        if (!isNotLock)
                        {
                            progress.progress++;
                        }
                        isNotLock.isDone = true;
                        
                    }
                    else
                    {
                        ClearInputNumberSprite();
                    }
                }
                else
                {
                    ClearInputNumberSprite();
                }
            }
            else
            {
                ClearInputNumberSprite();
            }
        }
        else
        {
            ClearInputNumberSprite();
        }
    }
    public void ClearInputNumberSprite()
    {
        inputNumberSprite[0].sprite = null;
        inputNumberSprite[1].sprite = null;
        inputNumberSprite[2].sprite = null;
        inputNumberSprite[3].sprite = null;
        currentIndex = 0;
    }
    public void PasswordInput1()
    {
        if (currentIndex < inputNumberSprite.Count)
        {
            inputNumberSprite[currentIndex].sprite = number[0];
            currentIndex++;
        }
    }
    public void PasswordInput2()
    {
        if (currentIndex < inputNumberSprite.Count)
        {
            inputNumberSprite[currentIndex].sprite = number[1];
            currentIndex++;
        }
    }
    public void PasswordInput3()
    {
        if (currentIndex < inputNumberSprite.Count)
        {
            inputNumberSprite[currentIndex].sprite = number[2];
            currentIndex++;
        }
    }
    public void PasswordInput4()
    {
        if (currentIndex < inputNumberSprite.Count)
        {
            inputNumberSprite[currentIndex].sprite = number[3];
            currentIndex++;
        }
    }
    public void PasswordInput5()
    {
        if (currentIndex < inputNumberSprite.Count)
        {
            inputNumberSprite[currentIndex].sprite = number[4];
            currentIndex++;
        }
    }
    public void PasswordInput6()
    {
        if (currentIndex < inputNumberSprite.Count)
        {
            inputNumberSprite[currentIndex].sprite = number[5];
            currentIndex++;
        }

    }
    public void PasswordInput7()
    {
        if (currentIndex < inputNumberSprite.Count)
        {
            inputNumberSprite[currentIndex].sprite = number[6];
            currentIndex++;
        }
    }
    public void PasswordInput8()
    {
        if (currentIndex < inputNumberSprite.Count - 1)
        {
            inputNumberSprite[currentIndex].sprite = number[7];
            currentIndex++;
        }
    }
    public void PasswordInput9()
    {
        if (currentIndex < inputNumberSprite.Count - 1)
        {
            Debug.Log("choose9");
            inputNumberSprite[currentIndex].sprite = number[8];
            currentIndex++;
        }

    }
}
