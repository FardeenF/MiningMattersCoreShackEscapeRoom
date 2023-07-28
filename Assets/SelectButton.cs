using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public GameObject buttonSelected;
    public GameObject Inventory;

    public void SetSelectButton()
    {
        Inventory.GetComponent<checkInventoryItem>().sb = this.gameObject.GetComponent<SelectButton>();
        buttonSelected = this.gameObject;
    }

    public GameObject GetSelectButton()
    {
        return buttonSelected;
    }
}
