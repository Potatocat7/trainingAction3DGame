using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDialog : MonoBehaviour
{
    [SerializeField] private int buttonNumber = 15;
    [SerializeField] private ItemButton itemButton;
    private ItemButton[] _itemButtons;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);
        for(var i = 0; i < buttonNumber - 1; i++)
        {
            Instantiate(itemButton, transform);
        }
        _itemButtons = GetComponentsInChildren<ItemButton>();
    }
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf)
        {
            for (var i = 0; i < buttonNumber; i++)
            {
                _itemButtons[i].OwnedItem = OwnedItemsData.Instance.OwnedItems.Length > i
                    ? OwnedItemsData.Instance.OwnedItems[i]
                    : null;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
