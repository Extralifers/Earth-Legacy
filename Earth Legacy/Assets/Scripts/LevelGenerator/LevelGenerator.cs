using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		rooms.Add(new Room(0, 1, "Room_001"));
		rooms.Add(new Room(1, 1, "Room_002"));
		rooms.Add(new Room(1, 2, "Room_003"));
		rooms.Add(new Room(2, 2, "Room_004"));
		rooms.Add(new Room(2, 1, "Room_005"));
		rooms.Add(new Room(1, 0, "Room_006"));
		rooms.Add(new Room(2, 0, "Room_007"));
		rooms.Add(new Room(1, 3, "Room_008"));
		rooms.Add(new Room(3, 3, "Room_009"));
		rooms.Add(new Room(3, 0, "Room_010"));
		rooms.Add(new Room(3, 1, "Room_011"));
		rooms.Add(new Room(3, 2, "Room_012"));
		rooms.Add(new Room(2, 3, "Room_013"));
	}
}
