using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	VoxelExtractionPointCloud vxe;
	public GameObject spawnObject;
	public Camera camera;
	int count = 0;
	int framecount = 0;
	// Use this for initialization
	void Start () {
		vxe = VoxelExtractionPointCloud.Instance;
		//for (int i=0; i<spawnObjects.Length; i++) 
		//	spawnObjects[i].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		framecount++;
		if(framecount % 120 != 0 || count > 5)
			return;

		Random.seed = (int)(Time.deltaTime * 1000);

		Vector3 ranPt = new Vector3 (Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), camera.nearClipPlane); 
		Vector3 startpt = camera.ViewportToWorldPoint (ranPt);
		Vector3 dir = startpt - camera.transform.position;
		Vector3 pos = new Vector3 (), normal = new Vector3 ();

		if (vxe.RayCast (startpt, dir, 50, ref pos, ref normal)) {
				GameObject newsphere = (GameObject)Instantiate (spawnObject, pos + normal * VoxelExtractionPointCloud.Instance.voxel_size * 0.5f, Quaternion.identity);
				newsphere.SetActive (true);
				newsphere.GetComponent<GrowScript>().init(pos, normal, (Vector3.Dot (normal,Vector3.up) > 0.999f) );
				count++;
		}

	}
}
