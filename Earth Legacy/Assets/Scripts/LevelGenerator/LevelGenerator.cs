using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LevelGenerator : MonoBehaviour {

	public static List<Room> rooms = new List<Room>();
	private int currentSize = 0;
	private int maxSize = 10;

	// Use this for initialization
	void Start () {
		buildRoomMap ();

		int inCode = 0;
		float nextPos = 0f;
		while ( currentSize < maxSize)
		{
			List<Room> rList = new List<Room> ();
			if(currentSize == maxSize - 1)  rList = getLastInRoom (inCode);
			else rList = getMedInRoom (inCode);
			Room r = rList[(int)Random.Range (0, rList.Count)];
			inCode = r.OutCode;

			GameObject room = (GameObject) Instantiate(Resources.Load(r.RoomName), new Vector3(nextPos, 0), new Quaternion(0, 0, 0, 0)); 
			nextPos += 45.85f; //47f
			currentSize++;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static List<Room> getMedInRoom(int inCode)
	{
		List<Room> roomList = new List<Room> ();
		foreach (Room r in rooms) 
		{
			if (r.InCode == inCode && r.OutCode != 0) {
				roomList.Add (r);
			}
		}
		return roomList;
	}

	public static List<Room> getLastInRoom(int inCode)
	{
		List<Room> roomList = new List<Room> ();
		foreach (Room r in rooms) 
		{
			if (r.InCode == inCode && r.OutCode == 0) {
				roomList.Add (r);
			}
		}
		return roomList;
	}

	public static void buildRoomMap()
	{
        string path = Application.dataPath + @"/Resources/rooms";
        var info = new DirectoryInfo(path);
        var fileInfo = info.GetFiles();
        string[] data;
        foreach (var file in fileInfo)
        {
            data = file.Name.Split('_');
            string[] namefile = file.Name.Split('.');
            if (namefile.Length == 2)
                rooms.Add(new Room(int.Parse(data[1]), int.Parse(data[2]), "rooms/"+namefile[0]));
        }
	}
}
