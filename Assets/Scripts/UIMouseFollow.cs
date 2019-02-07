using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMouseFollow : MonoBehaviour
{
    public Item myItem;

    RectTransform myTransform;
    Image sprite;

    private void Awake()
    {
        myTransform = GetComponent<RectTransform>();
        sprite = GetComponentInChildren<Image>();
    }

    private void LateUpdate()
    {
        if (myItem == null)
            myTransform.anchoredPosition = Vector2.zero;
        else
            myTransform.anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public void AssignItem(Item item)
    {
        //myItem = Instantiate(item);
        myItem = item;
        sprite.sprite = item.sprite;
    }

    public void RemoveItem()
    {
        myItem = null;
    }
}
