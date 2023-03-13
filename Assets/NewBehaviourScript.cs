using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NewBehaviourScript : MonoBehaviour {

	public NavMeshAgent ag;
	public GameObject ob;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public int lugar=2; 

	void Start () {
		lugar =1;
		obj3=ob;
	}
	
	// Update is called once per frame
	void Update () {
		float dx=transform.position.x-obj3.transform.position.x;
		float dz=transform.position.z-obj3.transform.position.z;
		float d=Mathf.Sqrt(dx*dx+dz*dz);
		if(d<1){
			if(lugar==1){
				lugar=2;
				obj3=obj2;
			}
			if(lugar==2){
				lugar=3;
				obj3=obj4;
			}
			
		}
		if (lugar==1){
			ag.SetDestination (ob.transform.position);
		}
		if(lugar==2)
		{
			ag.SetDestination (obj2.transform.position);
		}
		if(lugar==3)
		{
			ag.SetDestination (obj4.transform.position);
		}
	}
}
