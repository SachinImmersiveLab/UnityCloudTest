using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadPrefab : MonoBehaviour
{
    [SerializeField] private string prefabAddress;
    private GameObject addressable_prefab;
    private void Start()
    {

    }
   public void PrefabLoad()
    {
        Addressables.LoadAssetAsync<GameObject>(prefabAddress).Completed += OnLoadPrefab;
    }
    private void OnLoadPrefab(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            addressable_prefab = Instantiate(handle.Result);
            Debug.Log("loaded from addressables");
        }
        else
        {
            Debug.Log("error loading from addressables");

        }
    }

    public void ReleaseAddressable()
    {
        if(addressable_prefab != null)
        {         
            Addressables.Release(addressable_prefab);
            Debug.Log("addressable released");
            Destroy (addressable_prefab);
        }
    }
}
