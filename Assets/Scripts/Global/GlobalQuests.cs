using UnityEngine;
using System.Collections;

public class GlobalQuests {

    private static ArrayList _quests;

	public static void Init() {
	    


	}

    public ArrayList quests
    {
        get { return _quests; }
        set { _quests = value; }
    }
}
