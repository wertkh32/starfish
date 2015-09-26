using UnityEngine;
using System.Collections;

public enum AI_STATE
{
	MOVING = 0,
	STOPPED = 1
}

public class SimpleAI : MonoBehaviour {
	VoxelExtractionPointCloud vxe;
	// Use this for initialization
	void Start () {
		vxe = VoxelExtractionPointCloud.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
