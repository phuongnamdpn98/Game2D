using UnityEngine;
using UnityEngine.UI;

public class ScripttableManager : MonoBehaviour
{
    public Item[] item;
    public Image image;
    void Start()
    {
        Instantiate(item[Random.Range(0, 2)].prefab, transform.position, Quaternion.identity);
        Debug.Log(item[Random.Range(0, 2)].itemName);
        image.sprite = item[Random.Range(0, 2)].icon;
    }

    void Update()
    {
        
    }
}
