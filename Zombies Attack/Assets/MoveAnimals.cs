using UnityEngine;
using System.Collections;

public class MoveAnimals : MonoBehaviour {

	public GameObject zebra;
	public Camera c1;
	public Camera c2;
	int index = 0;
	public GameObject []blocks;
	// Use this for initialization
	void Start () {
		for(int i=0;i<blocks.Length;i++){
			blocks[i].SetActive(false);
		}
		c1.enabled = true;
		c2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		zebra.transform.position += new Vector3 (0.002f,0,0);

		if(Input.GetMouseButtonDown(0) )
		{
			if(index<blocks.Length){
			blocks[index].SetActive(true);
			index++;
			}else{
			c1.enabled = false;
			c2.enabled = true;
			}
		}
	}
}
