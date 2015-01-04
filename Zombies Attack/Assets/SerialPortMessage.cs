using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class SerialPortMessage : MonoBehaviour {

	SerialPort serialPort;
	public GameObject globe;
	BuildScript build;
	// Use this for initialization
	void Start () {
		build = globe.GetComponent<BuildScript> ();
		serialPort = new SerialPort("COM4", 57600);
		if(serialPort.IsOpen)
			serialPort.Close();

		serialPort.Open ();

		//SendMessageToPort ("GB\n");
	}
	
	// Update is called once per frame
	void Update () {
		if (serialPort.IsOpen )
		{
			//serialPort.DataReceived(
			//	serialPort.ReadExisting(
			serialPort.ReadTimeout = 1000;
			string value="";//
			//serialPort.ReadTimeout = 
			try{

				value = serialPort.ReadLine();
			}catch(System.TimeoutException e){
				print (e);
				value = "";
			} catch (System.Exception e) {
				print (e);
			}
			if(value == "NC")
				return;

			if(value != "" )
			{
				print(value);

				string[] w =  value.Split(',');
				if(w[0]=="BP")//Block Placed
				{
					int x = int.Parse(w[1]);
					int y = int.Parse(w[2]);
					build.BuildBlock(x,y);
				}
				else if(w[0]=="ABP")//Action Block Placed
				{
					int x = int.Parse(w[1]);
					int y = int.Parse(w[2]);
					build.BuildActionBlock(x,y);
				}
				else if(w[0]=="SA")//Shooting Arrow
				{
					build.ShootArrow();
				}
				else if(w[0]=="BR")//Block Removed
				{
					int x = int.Parse(w[1]);
					int y = int.Parse(w[2]);
					build.RemoveBlock(x,y);
				}
			}

			if(Input.GetKeyDown(KeyCode.Z))
			{
				SpawnZombie(0);
			}
			if(Input.GetKeyDown(KeyCode.X))
			{
				UpdateZombie();
			}
			if(Input.GetKeyDown(KeyCode.C))
			{
				KillZombie(0);
			}
		}
	}

	public void SpawnZombie(int n)//A new red light start
	{
		string msg = "SZ," + n.ToString();
		SendMessageToPort(msg);
	}

	public void UpdateZombie()//All red lights move forward one step
	{
		string msg = "UZ";
		SendMessageToPort(msg);
	}

	public void KillZombie(int n)//red light turn out
	{
		string msg = "KZ," + n.ToString();
		SendMessageToPort(msg);
	}

	public void SendMessageToPort(string msg){
		if(serialPort.IsOpen)
			serialPort.WriteLine (msg);
			//serialPort.Write(msg);
	}

	public void Destory(){
		if(serialPort.IsOpen)
			serialPort.Close();
	}
}
