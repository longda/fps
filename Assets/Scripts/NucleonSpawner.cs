using UnityEngine;


public class NucleonSpawner : MonoBehaviour
{
	public float timeBetweenSpawns;
	public float spawnDistance;
	public Nucleon[] nucleonPrefabs;

	float timeSinceLastSpawn;
	Transform nucleonHolder;

	void Start()
	{
		var holderName = "nucleons";
		if (transform.FindChild(holderName))
		{
			DestroyImmediate(transform.FindChild(holderName).gameObject);
		}

		nucleonHolder = new GameObject(holderName).transform;
		nucleonHolder.parent = transform;
	}

	void FixedUpdate()
	{
		timeSinceLastSpawn += Time.deltaTime;

		if (timeSinceLastSpawn >= timeBetweenSpawns)
		{
			timeSinceLastSpawn -= timeBetweenSpawns;
			SpawnNucleon();
		}
	}

	void SpawnNucleon()
	{
		Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
		Nucleon spawn = Instantiate<Nucleon>(prefab);
		spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
		spawn.transform.parent = nucleonHolder;
	}
}
