using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploySound : MonoBehaviour
{
    public GameObject soundPrefab;
    public float respawnTime = 1f;

    [Header("Scripts")]
    public GameObject spawnStartPoint;
    public Drumzone DrumzoneScript;

    void Start()
    {
        StartCoroutine(SoundWave());
    }

    private void SpawnSound()
    {
        if (DrumzoneScript.ventOpen == true)
        {
            //hier kann man auch dann sp�ter particle/Feedback effecte reinhauen.   
            GameObject clone = Instantiate(soundPrefab) as GameObject;
            clone.transform.position = spawnStartPoint.transform.position;
        }

    }

    IEnumerator SoundWave()
    {

        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnSound();
        }
    }

}
