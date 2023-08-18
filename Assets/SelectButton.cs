using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public GameObject buttonSelected;
    public GameObject Inventory;

    public GameObject[] itemSlots;

    public void SetSelectButton()
    {
        Inventory.GetComponent<checkInventoryItem>().sb = this.gameObject.GetComponent<SelectButton>();
        buttonSelected = this.gameObject;
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSelectButton();
            Inventory.GetComponent<checkInventoryItem>().sb = itemSlots[0].gameObject.GetComponent<SelectButton>();
            buttonSelected = itemSlots[0].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSelectButton();
            Inventory.GetComponent<checkInventoryItem>().sb = itemSlots[1].gameObject.GetComponent<SelectButton>();
            buttonSelected = itemSlots[1].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetSelectButton();
            Inventory.GetComponent<checkInventoryItem>().sb = itemSlots[2].gameObject.GetComponent<SelectButton>();
            buttonSelected = itemSlots[2].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSelectButton();
            Inventory.GetComponent<checkInventoryItem>().sb = itemSlots[3].gameObject.GetComponent<SelectButton>();
            buttonSelected = itemSlots[3].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetSelectButton();
            Inventory.GetComponent<checkInventoryItem>().sb = itemSlots[4].gameObject.GetComponent<SelectButton>();
            buttonSelected = itemSlots[4].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetSelectButton();
            Inventory.GetComponent<checkInventoryItem>().sb = itemSlots[5].gameObject.GetComponent<SelectButton>();
            buttonSelected = itemSlots[5].gameObject;
        }
    }

    public GameObject GetSelectButton()
    {
        return buttonSelected;
    }
}
