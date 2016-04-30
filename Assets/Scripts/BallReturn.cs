using UnityEngine;
using System.Collections;

public class BallReturn : MonoBehaviour {
	
	public int _Ball = 0;
	bool doUpdate = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void LateUpdate()
	{
		if (doUpdate)
		{
			_Ball += 1;
			_Ball = _Ball % 3;
			StartCoroutine(DelayUpdate());	
		}
		doUpdate = false;
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.GetComponent<BallThrower>() != null)
			{
			doUpdate = true;							
			other.gameObject.SendMessage("Reset", _Ball, SendMessageOptions.DontRequireReceiver);
			}		
    }
	
	void ResetFrame()
	{
		Debug.Log("Resetting pins");
		foreach ( var v in GameObject.FindGameObjectsWithTag("Pin"))
		{
			v.SendMessage("ResetPin", (_Ball),SendMessageOptions.DontRequireReceiver);
		}
		_Ball = 0;
	}
	
	public IEnumerator DelayUpdate()
	{
		Debug.Log("waiting");
		yield return new WaitForSeconds(1.5f);
		Debug.Log("scoring");
		gameObject.SendMessage("UpdateScore", _Ball, SendMessageOptions.RequireReceiver);
		yield return 0;
	}
	
}
