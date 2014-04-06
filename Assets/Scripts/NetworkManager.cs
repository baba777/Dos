using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private void StartServer()
	{
		var useNAT = !Network.HavePublicAddress();
		Network.InitializeServer(2, 25000, useNAT);
		MasterServer.RegisterHost("test", "dos");
	}

	void OnServerInitialized()
	{
		print("test");
	}

	// Use this for initialization
	void Start () 
	{
		StartServer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
