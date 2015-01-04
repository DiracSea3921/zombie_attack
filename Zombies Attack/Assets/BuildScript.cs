using UnityEngine;
using System.Collections;

public class BuildScript : MonoBehaviour {

	public GameObject zombies;
	public GameObject bullet;
	public GameObject []blocks;
	public AudioClip build;
	public AudioClip finished;
	public GameObject serial;
	private int spawnTime = 10;
	private int updateTime = 4;
	//Queue queue;
	private float time;
	private float u_time;
	private float a_time;
	int index = 0;
	SerialPortMessage serialPort;
	int zombieCount = 0;

	// Use this for initialization
	void Start () {
		time =  Time.time - spawnTime;
		u_time = Time.time; 
		a_time = Time.time; 
		//queue = new Queue();
		serialPort = serial.GetComponent<SerialPortMessage> ();
		for(int i=0;i<blocks.Length;i++){
			blocks[i].SetActive(false);
		}
	}

	public void BuildBlock(int x,int y)
	{
		if(index<blocks.Length)
		{
			blocks[index].SetActive(true);
			index++;
			if(index<blocks.Length)
				AudioSource.PlayClipAtPoint(build,gameObject.transform.position,100.0f );
			else
				AudioSource.PlayClipAtPoint(finished,gameObject.transform.position,100.0f );
		}
	}

	public void BuildActionBlock(int x,int y)
	{
		if(index<blocks.Length)
		{
			blocks[index].SetActive(true);
			index++;
			if(index<blocks.Length)
				AudioSource.PlayClipAtPoint(build,gameObject.transform.position,100.0f );
			else
				AudioSource.PlayClipAtPoint(finished,gameObject.transform.position,100.0f );
		}
	}

	public void ShootArrow(){

		if(a_time>1.0f){
			a_time = 0.0f;
			Vector3 pos = new Vector3(54.5f,19.4f,36.8f);
			
			GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie"); 
			float distance = 999999;
			GameObject zombie = null;
			foreach(GameObject z in zombies){
				if((z.transform.position - pos).magnitude<distance)
				{
					if(z.GetComponent<ZombieController>().IsAlive()){
					distance = (z.transform.position - pos).magnitude;
					zombie = z;
					}
				}
			}
			if(zombie!=null){
				GameObject obj = Instantiate (bullet,pos,Quaternion.identity) as GameObject;
				obj.GetComponent<Bullet>().SetTarget(ref zombie);
			}
		}
	}

	public void RemoveBlock(int x,int y)
	{
	}
	// Update is called once per frame
	void Update () {
		a_time += Time.deltaTime;
		if(Time.time - u_time >updateTime)
		{
			GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");
			if(zombies.Length>0){
				u_time = Time.time;
				print("Update Zombie");
				serialPort.UpdateZombie();
			}
		}

		if(Time.time - time >spawnTime)
		{
			time = Time.time;
			GameObject obj = Instantiate (zombies,new Vector3(3,0,27f),Quaternion.identity) as GameObject;
			ZombieController zc = obj.GetComponent<ZombieController>();
			//zc.queue = queue;
			zc.SetID(zombieCount);
			zc.SetSerialPort(serialPort);
			obj.transform.localScale = new Vector3(35.0f,35.0f,35.0f);
			obj.tag = "zombie";
			//queue.Enqueue(obj);
			print("Spawn Zombie" +zombieCount);
			zombieCount++;
			serialPort.SpawnZombie(zombieCount);

		}
		if(Input.GetMouseButtonDown(0))
		{
			BuildBlock(0,0);
		}
		if(Input.GetMouseButtonDown(1))
		{
			ShootArrow();
		}
	}


}
