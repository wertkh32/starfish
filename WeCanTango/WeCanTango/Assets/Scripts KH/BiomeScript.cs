using UnityEngine;
using System.Collections;

public enum BIOMES
{
	grass = 0,
	sand = 1,
	stone = 2,
	dirt = 3
}

public class BiomeScript : MonoBehaviour {
	VoxelExtractionPointCloud vxe;
	GameObject[,,] chunkObjs;

	[HideInInspector]
	public BIOMES[,] biomeMap; 

	public Material[] materials;

	int num_chunks_x;
	int num_chunks_y;
	int num_chunks_z;
	// Use this for initialization
	void Start () {
		vxe = VoxelExtractionPointCloud.Instance;
		chunkObjs = vxe.chunkGameObjects;

		num_chunks_x = vxe.num_chunks_x;
		num_chunks_y = vxe.num_chunks_y;
		num_chunks_z = vxe.num_chunks_z;

		initBiomes ();
	}

	void initBiomes()
	{
		biomeMap = new BIOMES[num_chunks_x,num_chunks_z];
		Random.seed = (int)(Random.value * Random.value * Random.value * 101.0f);
		for(int i=0;i<num_chunks_x;i++)
			for(int j=0;j<num_chunks_z;j++)
		{
			int mat = Random.Range (0,materials.Length);

			for(int k=0;k<num_chunks_y;k++)
			{
				chunkObjs[i,k,j].GetComponent<MeshRenderer>().material = materials[mat];
			}

			biomeMap[i,j] = (BIOMES)mat;
		}
	}

	public void resetBiomes()
	{
		for(int i=0;i<num_chunks_x;i++)
			for(int j=0;j<num_chunks_z;j++)
				for(int k=0;k<num_chunks_y;k++)
				{
					chunkObjs[i,k,j].GetComponent<MeshRenderer>().material = materials[(int)biomeMap[i,j]];
				}
	}

	public void setAllMaterials(Material mat)
	{
		for (int i=0; i<num_chunks_x; i++)
			for (int j=0; j<num_chunks_z; j++)
				for (int k=0; k<num_chunks_y; k++) 
			{
				chunkObjs[i,k,j].GetComponent<MeshRenderer>().material = mat;
			}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
