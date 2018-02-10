using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolHandler : MonoBehaviour 
{
    Dictionary<int, Queue<GameObject>> poolDictionary= new Dictionary<int, Queue<GameObject>>();


	public void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<GameObject>());
        }
    }

}
