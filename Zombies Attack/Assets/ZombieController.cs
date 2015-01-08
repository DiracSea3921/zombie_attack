using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	Vector3 []points;
	int index;
	float speed =0.04f;
	public bool alive = true;
	//public Queue queue;
	int id = -1;
	float timer = 0;
	private SerialPortMessage serialPort;
	// Use this for initialization
	void Start () {
		points = new Vector3[3];
		points [0] = new Vector3 (38.2f,0,27.0f);
		points [1] = new Vector3 (38.2f,0,99.5f);
		points [2] = new Vector3 (90.3f,0,99.4f);
		index = 0;
	}

	public int GetID(){
		return id;
	}

	public void SetID(int i)
	{
		id = i;
	}

	public bool IsAlive()
	{
		return alive;
	}
	public void SetSerialPort(SerialPortMessage serialPort)
	{
		this.serialPort = serialPort;
	}

	// Update is called once per frame
	void Update () {
		if (!alive){
			if(timer<2.0)
				timer+=Time.deltaTime;
			else
				Destroy(gameObject);
			return;
		}

		if((gameObject.transform.position-points[index]).magnitude<0.1f){
			if(index >=2){
				GameObject village = GameObject.FindGameObjectWithTag("village");
				village.GetComponent<village>().Damage();
				Destroy(gameObject);
				return;
			}
			index++;
		}
		Vector3 tmp = (points [index] - gameObject.transform.position);
		tmp.y = 0;
		Vector3 dir = tmp.normalized;

		;
		gameObject.transform.position += dir * speed / (1.0f/60.0f) * Time.deltaTime;
		Quaternion q = Quaternion.FromToRotation (new Vector3 (0, 0, 1), dir);
		gameObject.transform.localRotation = q;
	}

	void OnCollisionEnter(Collision collision){
		Collider collider = collision.collider;
		if (collider.CompareTag ("bullet") && alive) {
			animation.Play("death01");
			alive = false;
			serialPort.KillZombie(id);
			print ("kill zombie"+id);
			//queue.Dequeue();
		}
		
	}
}
