using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item2Show : BaseItem
{
    
    public ObjectEventSO ChangeDescption;
    private Image image;
    protected override void Awake()
    {
        
    }

    public void Init(ItemSO itemData)
    {
        this.itemData = itemData;
        image = GetComponent<Image>();
        image.sprite = itemData.itemImage;
        animationShow();
    }

    
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        showDescription();
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        
    }

    private void showDescription()
    {
        string description = itemData?.introduction;
        ChangeDescption.RaiseEvent(description,this);
        
    }

    

    private void animationShow()
    {
        this.transform.localScale = Vector3.zero;
        this.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f);
    }
}
