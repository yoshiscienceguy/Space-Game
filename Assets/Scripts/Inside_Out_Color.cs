﻿using UnityEngine;
using System.Collections;

public class Inside_Out_Color : MonoBehaviour {

	void Start () 
	{
		//get a reference to the mesh
		MeshFilter BaseMeshFilter = transform.GetComponent("MeshFilter") as MeshFilter;
		Mesh mesh = BaseMeshFilter.mesh;
		
		//reverse triangle winding
		int[] triangles= mesh.triangles;
		    
		int numpolies = triangles.Length / 3;
		for(int t=0;t < numpolies;t++)
		{
			int tribuffer = triangles[t*3];
			triangles[t*3]=triangles[(t*3)+2];
			triangles[(t*3)+2]=tribuffer;
		}
		
		//readjust uv map for inner sphere projection
		Vector2[] uvs = mesh.uv;
		for(int uvnum = 0;uvnum < uvs.Length;uvnum++)
		{
			uvs[uvnum]=new Vector2(1-uvs[uvnum].x,uvs[uvnum].y);
		}
		 
			//readjust normals for inner sphere projection    
			Vector3[] norms = mesh.normals;        
		for(int normalsnum = 0;normalsnum < norms.Length;normalsnum++)
		{
			norms[normalsnum]=-norms[normalsnum];
		}
		
		//copy local built in arrays back to the mesh
		mesh.uv = uvs;
		mesh.triangles=triangles;
		mesh.normals=norms;    
	} 


}
