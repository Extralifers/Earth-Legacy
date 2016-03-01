using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ItemGenerator : MonoBehaviour {

    public static List<Item> items = new List<Item>();

	// Use this for initialization
	void Start () {

        initializePools();

        Item ItemRandom = items[(int)Random.Range(0F, items.Count)];
        //Item ItemRandom = items[0];
        //Debug.Log(ItemRandom.itemName);

        //Descubrir como saber la posicion de la habitacion en la que esta

        this.gameObject.AddComponent<Item>();
        GameObject itemprueba = (GameObject) Instantiate(Resources.Load(ItemRandom.itemName), this.gameObject.transform.position+ new Vector3(0, -3F, 0F), new Quaternion(0, 0, 0, 0));
    }

    // Update is called once per frame
    void Update () {
	
	}

    void initializePools()
    {
        string path = Application.dataPath + @"/Resources/ItemPrefabs";
        var info = new DirectoryInfo(path);
        var fileInfo = info.GetFiles("*.prefab");

        foreach (var file in fileInfo)
        {
            
            string[] namefile = file.Name.Split('.');
            Debug.Log(file.Name);
            items.Add(new Item("ItemPrefabs/"+namefile[0]));
        

        }
        /*foreach (var item in items)
        {
            if (item == null)
            {
                Debug.Log("Puntero a null en un objeto");
            }
            else
            {
                Debug.Log(item.ToString());
            }

        }*/
    }
}
