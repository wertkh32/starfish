using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
	public OrientationTrigger[] switches;
	GameObject[] switchObjects;
	public BiomeScript biome;
	public Material tranformMat;
	bool triggered = false;
	public Camera leftcam;
	public Camera rightcam;
	public Light light;
	public ParticleSystem partsys;
	public GameObject obj;
	// Use this for initialization
	void Start () {
		switchObjects = new GameObject[switches.Length];

		for (int i=0; i<switches.Length; i++)
			switchObjects [i] = switches [i].gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered)
			return;
		for(int i=0;i<switches.Length;i++)
		{
			if(!switches[i].triggered)
				return;
		}

		
		
		
		partsys.startLifetime = 3;
		partsys.startColor = Color.cyan;
		partsys.startSpeed = 2.0f;
		partsys.startSize = 0.3f;
		partsys.maxParticles = 500;
		partsys.Clear ();
		partsys.Stop ();
		partsys.Emit (500);
		obj.SetActive (false);
		for (int i=0; i<switches.Length; i++)
			switchObjects [i].SetActive (false);

		StartCoroutine(worldTransform());
		triggered = true;
	}

	IEnumerator worldTransform()
	{
		biome.setAllMaterials (tranformMat);
		leftcam.clearFlags = CameraClearFlags.Skybox;
		rightcam.clearFlags = CameraClearFlags.Skybox;
		light.intensity = 1.0f;
		yield return new WaitForSeconds(10.0f);
		leftcam.clearFlags = CameraClearFlags.SolidColor;
		rightcam.clearFlags = CameraClearFlags.SolidColor;
		light.intensity = 0.3f;
		biome.resetBiomes ();
	}
}
