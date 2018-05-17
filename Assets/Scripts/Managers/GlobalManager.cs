using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalManager : object
{
	//will not be destroyed after loading
	public static bool isServer = true;
	public static string serverIP = "";
	public static int playerCarIndex = 0;
}
