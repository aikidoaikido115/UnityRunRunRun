using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//ไม่ใช้ละ
public class TimerScene : MonoBehaviour
{
    public GameObject[] backgroundPrefabs;  // Array of background prefabs
    private GameObject currentBackground;
    private int currentBackgroundIndex = 0;
    public float changeInterval = 10f;

    void Start()
    {
        // Start the timer coroutine
        StartCoroutine(ChangeBackgroundTimer());
    }

    IEnumerator ChangeBackgroundTimer()
    {
        while (true)
        {
            Debug.Log("Coroutine Executed");
            // Wait for the specified interval
            yield return new WaitForSeconds(changeInterval);

            // Change the background prefab
            ChangeBackground();
        }
    }

    void ChangeBackground()
    {
        Debug.Log("ChangeBackground method called");
        // Destroy the current background if it exists
        if (currentBackground != null)
        {
            Destroy(currentBackground);
        }

        // Instantiate the new background prefab
        currentBackground = Instantiate(backgroundPrefabs[currentBackgroundIndex], transform.position, Quaternion.identity);
        currentBackground.transform.SetParent(transform);
        Debug.Log("Instantiated: " + currentBackground.name);
        // Increment the background index
        currentBackgroundIndex = (currentBackgroundIndex + 1) % backgroundPrefabs.Length;
    }
}
