using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {
	
	public float _Spin;
	public float _Power;
	public float _Throw = 20;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > .1)
			return;
		
	if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 addition = Vector3.forward * Time.deltaTime;
			gameObject.transform.position += addition;
		}
	if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 addition = Vector3.forward * Time.deltaTime;
			gameObject.transform.position -= addition;
		}
	

	if (Input.GetKey(KeyCode.Space))
		{
			_Power += _Throw * 1000 * Time.deltaTime;
		}		
	
	if (Input.GetKeyUp(KeyCode.Space))
	{
		StartCoroutine(Throw());
	}
		
	}

	public IEnumerator Throw()
	{
		gameObject.GetComponent<ConstantForce>().force = new Vector3(_Power * -1, 0,0);
		gameObject.GetComponent<ConstantForce>().relativeForce = gameObject.GetComponent<ConstantForce>().force * .1f;
		gameObject.GetComponent<ConstantForce>().torque = new Vector3(-100, _Spin, 0);
		yield return 0;
		gameObject.GetComponent<ConstantForce>().force = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().torque =  Vector3.zero;
		
		yield  break;
		
	}
	
	public void Reset(object _ball)
	{
		// _ball is ignored 
		_Power = 0;
		_Spin = Random.Range(-100, 100);
		gameObject.GetComponent<ConstantForce>().force =Vector3.zero;
		gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().torque = Vector3.zero;
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		
	
	}
		

}


