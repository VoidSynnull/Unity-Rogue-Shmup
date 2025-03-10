using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour {
    public List<Transform> propSpawnPoints;
    public List<GameObject> propPrefabs;

    // Start is called before the first frame update
    void Start() {
        SpawnProps();
    }

    // Update is called once per frame
    void Update() {

    }

    void SpawnProps() {
        foreach (Transform transform in propSpawnPoints) {
            int rand = Random.Range(0, propPrefabs.Count);

           GameObject prop = Instantiate(propPrefabs[rand], transform.position, Quaternion.identity);
            prop.transform.parent = transform;
        }
    }

}