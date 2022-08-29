using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    [SerializeField]
    private int PoolOfMush;
    private List<GameObject> PooledMush;
    public Transform poolparent, originalparent;
    //private GameObject MushtoSpawn;

    private void Start()
    {
        PooledMush = new List<GameObject>();
        for (int i = 0; i < PoolOfMush; i++)
        {
            Instantiate(objPrefab, transform.position, Quaternion.identity, poolparent);
            objPrefab.SetActive(false);
            PooledMush.Add(objPrefab);
        }
    }

    void FixedUpdate()
    {
        MushRain();
    }
    private GameObject GetPooledMush()
    {
        for (int i = 0; i < PoolOfMush; i++)
        {
            if (!PooledMush[i].activeSelf)
            {
                return PooledMush[i];
            }
        }
        return null;
    }

    public void MushRain()
    {
        GameObject MushtoSpawn = GetPooledMush();
        if (MushtoSpawn != null)
        {
            //MushtoSpawn.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            MushtoSpawn.transform.position = new Vector3 (0, 50, 50);
            MushtoSpawn.transform.rotation = new Quaternion(0, 0, 0, 0);
            MushtoSpawn.SetActive(true);
            Debug.Log(MushtoSpawn.activeSelf);
            Debug.Log(PooledMush.Capacity);
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("msk" + MushtoSpawn + i);
            }
            
        }
        //MushtoSpawn.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
    }
}
