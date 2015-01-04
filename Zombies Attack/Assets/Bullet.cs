using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private GameObject target;
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	public void SetTarget(ref GameObject target)
	{
		this.target = target;
	}
	// Update is called once per frame
	void Update () {
		if(target!=null){
			Vector3 dir = (target.transform.position - gameObject.transform.position).normalized;
			gameObject.transform.position += dir * speed /(1/60.0f)*Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision collision){
		Collider collider = collision.collider;
		if (collider.CompareTag ("zombie")) {
			Destroy(gameObject);
		}
		
	}
}
