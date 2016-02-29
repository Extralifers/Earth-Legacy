using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ItemGenerator : MonoBehaviour {

    List<Object> items = new List<Object>();

	// Use this for initialization
	void Start () {
        string path = Application.dataPath + @"/Prefabs/ItemPrefabs";
        var info = new DirectoryInfo(path);
        var fileInfo = info.GetFiles();

        foreach (var file in fileInfo)
        {
            Debug.Log(file.Name);
            items.Add(Resources.Load("file.Directory"));

        }

        foreach (var item in items)
        {
            if(item == null)
            {
                Debug.Log("Puntero a null en un objeto");
            }
            else
            {
                Debug.Log(item.ToString());
            }

        }

        //Descubrir como saber la posicion de la habitacion en la que esta
        int numItemRandom = (int)Random.Range(0F, 2F);

        Instantiate(items[numItemRandom], new Vector3(18F, -6F, -1F), new Quaternion(0, 0, 0, 0));

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
