using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour 
{
	public GameObject eyeLids;
	
	private void Start ()
	{
		StartCoroutine("animateBlink");
	}
	
	public void BlinkEyes()
	{
		eyeLids.SetActive(false);
		StartCoroutine("animateBlink");
	}
	
	public void CloseEyes(bool dead)
	{
		if(dead)
		{
			StopCoroutine("animateBlink");
			StartCoroutine("closeEyesDead");
		}
		
		else
		{
			eyeLids.SetActive(true);
			StopCoroutine("animateBlink");
		}
	}
	
	private IEnumerator closeEyesDead()
	{
		yield return new WaitForSeconds(2.0f);
		eyeLids.SetActive(true);
	}
	
	private IEnumerator animateBlink()
	{
		float randWait = Random.Range(1.0f, 4.0f);
		
		yield return new WaitForSeconds(randWait);
		
		eyeLids.SetActive(true);
		
		yield return new WaitForSeconds (0.1f);
		
		eyeLids.SetActive(false);
		
		yield return new WaitForSeconds (0.1f);		
				
		StartCoroutine("animateBlink");
	}	
}
