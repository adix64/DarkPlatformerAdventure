using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinnedMeshParticleTracker : MonoBehaviour {
	ParticleSystem particleSys;

	void Start () {
		SkinnedMeshRenderer skinnedMesh = GameObject.FindWithTag ("Player").transform.Find ("PlayerMesh").GetComponent<SkinnedMeshRenderer> ();	
		particleSys = GetComponent<ParticleSystem> ();
		var psm = particleSys.shape;
		psm.shapeType = ParticleSystemShapeType.SkinnedMeshRenderer;
		psm.meshShapeType = ParticleSystemMeshShapeType.Triangle;
		psm.skinnedMeshRenderer = skinnedMesh;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
