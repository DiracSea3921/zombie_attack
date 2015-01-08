using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class village : MonoBehaviour {

	private int HP = 100;
	public GameObject shield;
	public Texture t1;
	public Texture t2;
	public Texture t3;
	public Texture t4;
	public Texture2D t5;

	// Use this for initialization
	void Start () {
		HP = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(HP==100)
			shield.renderer.material.SetTexture ("_MainTex", t1);
		else if(HP==80)
			shield.renderer.material.SetTexture ("_MainTex", t2);
		else if(HP==60)
			shield.renderer.material.SetTexture ("_MainTex", t3);
		else if(HP==40)
			shield.renderer.material.SetTexture ("_MainTex", t4);
		else
			shield.renderer.material.SetTexture ("_MainTex", t5);
	}

	public void Damage(){
		HP -= 20;
	}

	void OnGUI() {



		/*if(HP==100)
			GUI.DrawTexture(new Rect(Screen.width/2-100,Screen.height/2-120, 200, 20), t1, ScaleMode.StretchToFill, true);
		else if(HP==80)
			GUI.DrawTexture(new Rect(Screen.width/2-100,Screen.height/2-120, 160, 20), t2, ScaleMode.StretchToFill, true);
		else if(HP==60)
			GUI.DrawTexture(new Rect(Screen.width/2-100,Screen.height/2-120, 120, 20), t3, ScaleMode.StretchToFill, true);
		else if(HP==40)
			GUI.DrawTexture(new Rect(Screen.width/2-100,Screen.height/2-120, 80, 20), t4, ScaleMode.StretchToFill, true);
		else
			GUI.DrawTexture(new Rect(Screen.width/2-100,Screen.height/2-120, 40, 20), t5, ScaleMode.StretchToFill, true);

		GameObject text = GameObject.Find ("Text");//.FindGameObjectWithTag("text");
		if(text!=null)
			text.GetComponent<Text>().text = "Life: "+HP;*/
	}

}
