using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class copy1 : MonoBehaviour {

	public NavMeshAgent ag;
	public GameObject ob;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject com;
	//public GameObject pel;
	public GameObject safe;
	public GameObject aux;
	public int lugar=2; 
    public int olfato=6;
    public float vel=3.5f;
    public int put=0;
	public string est1="buscar";
	public string est2="ir";
	public string est3="escapar";
	public string estAct="buscar";
	private int t=0;
	        public GameObject c2;//frontal ray
	void Start () {
		estAct=est1;

		aux=ob;
	}
	
	// Update is called once per frame
	void Update () {
		t++;
		Vector3 v3=c2.transform.right;
		//Debug.Log("adelante vel"+v3);
        v3[2]=(Mathf.Sin(t));
        RaycastHit hit2;
		if (estAct==est1)
		{

			ag.SetDestination (aux.transform.position);
			float dx=transform.position.x-aux.transform.position.x;
			float dz=transform.position.z-aux.transform.position.z;
			float d=Mathf.Sqrt(dx*dx+dz*dz);
			if(d<1){
				float r=Random.Range(0,4);
				if(r<1){
				aux=obj2;
				}else{
					if(r<2)
					{
					aux=obj3;
					}else{
						if(r<3){
						  aux=obj4;
						}else{
						  aux=ob;	
						}
						
					}
				}
				
			}
			float dqx=transform.position.x-com.transform.position.x;
			float dqz=transform.position.z-com.transform.position.z;
			float dq=Mathf.Sqrt(dqx*dqx+dqz*dqz);
			if(Physics.Raycast(c2.transform.position,v3,out hit2, 5f)){
				Debug.DrawLine(c2.transform.position, hit2.point);
				Debug.Log(hit2.rigidbody); 
				if (hit2.rigidbody==com.GetComponent<Rigidbody>()&&hit2.distance<=2){
					estAct=est2;
				}
				
			}
			//float dpx=transform.position.x-pel.transform.position.x;
			//float dpz=transform.position.z-pel.transform.position.z;
			//float dp=Mathf.Sqrt(dpx*dpx+dpz*dpz);
			//if(dp<olfato-4){
			//	estAct=est3;
			//}
		}else if(estAct==est2){
			aux=com;
			int d=0;
			ag.SetDestination (aux.transform.position);
			if(Physics.Raycast(c2.transform.position,v3,out hit2, 5f)){
				Debug.DrawLine(c2.transform.position, hit2.point);
				Debug.Log(hit2.rigidbody); 
				if (hit2.rigidbody==com.GetComponent<Rigidbody>()&&hit2.distance>=10){
					estAct=est1;
				}
				else if (hit2.rigidbody==com.GetComponent<Rigidbody>()&&hit2.distance<=2){
					estAct=est3;
				}
				
			}
			/*for (int i=0;i<100;i++){
			float dex=transform.position.x-pel.transform.position.x;
			float dez=transform.position.z-pel.transform.position.z;
			float de=Mathf.Sqrt(dex*dex+dez*dez);
			if(de<olfato-4){
				estAct=est3;
				break;
				}
				d++;
			}*/

			if (d>=90){
				//com.transform.position.x=Random.Range(0,50);
				//com.transform.position.z=Random.Range(0,50);
				put++;
			}


		}else if(estAct==est3){
			Debug.Log("bang");
			aux=safe;
			ag.SetDestination (aux.transform.position);
			estAct=est1;
		}
		
		/*float dx1=transform.position.x-obj3.transform.position.x;
		float dz1=transform.position.z-obj3.transform.position.z;
		float d1=Mathf.Sqrt(dx1*dx1+dz1*dz1);
		if(d1<1){

			if(lugar==1){
				lugar=2;
				obj3=ob;
			}
			
		}
		if (lugar==1){
			ag.SetDestination (ob.transform.position);
		}
		if(lugar==2)
		{
			ag.SetDestination (obj2.transform.position);
		}*/
	}
}
