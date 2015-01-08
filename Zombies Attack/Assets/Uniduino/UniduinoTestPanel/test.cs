using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
public class test : MonoBehaviour {

	SerialPort serialPort;

	void Start () {
		//var ports = SerialPort.GetPortNames();
		serialPort = new SerialPort("COM3", 9600);
		//serialPort.Open ();
	}
	void Update () {
		if (serialPort.IsOpen){
			string value = serialPort.ReadLine();
			if(value != "" )
			{
				Debug.Log (value);
			}
		}else{
			serialPort.Open ();
		}
	}

}
