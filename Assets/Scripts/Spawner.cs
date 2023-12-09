using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f,1f)]
        public float spawnChance;
    }
    public SpawnableObject[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
        Invoke(nameof(special_spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;
        var special_obj = objects[7];

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void special_spawn()
    {
        float spawnChance = Random.value;
        if (spawnChance < objects[0].spawnChance)
        {
            GameObject obstacle_base = Instantiate(objects[0].prefab);
            GameObject obstacle_sky = Instantiate(objects[7].prefab);
            obstacle_base.transform.position += transform.position;
            obstacle_sky.transform.position += transform.position;
        }
        //spawnChance -= objects[1].spawnChance;
        //spawnChance -= objects[7].spawnChance;
        Invoke(nameof(special_spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
