using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryDisplay : MonoBehaviour
{
    public InventoryObject inventory;

    public int x_space;
    public int y_pace;
    public int n_column;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {

            CreateSlot();        


        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(x_space * (i % nColumn), (-y_space * (i / n_column)), 0f);
    }

    public void CreateSlot()
    {
        var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        itemsDisplayed.Add(inventory.Container[i], obj);
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {

            }
            else
            {
                CreateSlot(); 
            }
        }
    }
}
