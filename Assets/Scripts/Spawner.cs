using UnityEngine;
using System.Collections;

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

    public int starvation_counter = 0;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;
        
        //Debug.Log(spawnChance);

        var starvation_obj_arr = new[] { objects[8], objects[9], objects[10], objects[11], objects[12], objects[13]};

        foreach (var obj in objects)
        {
            StartCoroutine(TimeSleep(2.0f));
            //Debug.Log("2 s wait");
            if (spawnChance < obj.spawnChance)
            {
                starvation_counter += 1;
                Debug.Log(starvation_counter);
                if (starvation_counter < 3)
                {
                    GameObject obstacle = Instantiate(obj.prefab);
                    obstacle.transform.position += transform.position;
                    break;
                }
                else
                {
                    int RandomNumber = GenerateRandomNumber(0, 6);
                    //Debug.Log(RandomNumber);
                    //Debug.Log(starvation_obj_arr[RandomNumber]);
                    GameObject obstacle = Instantiate(starvation_obj_arr[RandomNumber].prefab);
                    obstacle.transform.position += transform.position;
                    starvation_counter = 0;
                    break;
                }

                
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
    IEnumerator TimeSleep(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    int GenerateRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
}
