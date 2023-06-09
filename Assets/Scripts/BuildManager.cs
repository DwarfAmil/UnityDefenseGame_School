using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    
    void Awake ()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        Instance = this;
    }
    
    public GameObject standardTurretPrefab;
    
    void Start()
    {
        _turretToBuild = standardTurretPrefab;
    }
    
    private GameObject _turretToBuild;
    
    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

}
