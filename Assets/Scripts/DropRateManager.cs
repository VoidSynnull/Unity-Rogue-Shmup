using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops {
        public string name;
        public GameObject prefab;
        public float dropRate;
    }

    public List<Drops> drops;

    private void OnDestroy() {
        //Prevents error on stopping play in editor
        if(!gameObject.scene.isLoaded) {
            return;
        }
        float randomNum = UnityEngine.Random.Range(0, 100f);
        List<Drops> possibleDrops = new List<Drops>();
        foreach(Drops drop in drops) {
            if (randomNum <= drop.dropRate)
            {
                //add item to drop list
                possibleDrops.Add(drop);
            }
        }

        //Now check possible drops
        if (possibleDrops.Count > 0) {
        
            Drops drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
            Instantiate(drops.prefab, transform.position, Quaternion.identity);
        }
    }
}
