using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoldConroller : MonoBehaviour
{
    [SerializeField] private BlackHoldConfig config;

    private Collider[] _listHitCollider = new Collider[10];
    private void Update()
    {
        // RayCast sphere to detect object shucked by blackHold
        foreach (var range in config.listForceConfigs)
        {
            var detectedObject = Physics.OverlapSphereNonAlloc(transform.position, range.range, _listHitCollider);
            foreach (var hit in _listHitCollider)
            {
                var iBlackHold = hit.GetComponent<IBlackHold>();
                if (iBlackHold != null)
                {
                    iBlackHold.SuckByBlackHold();
                    ActionWithOtherObject(hit);
                }
            }
        }
    }

    private void ActionWithOtherObject(Collider other)
    {
        // Suck object into center of blackHold
        var force = CalculateForce();
        var dir = transform.position - other.transform.position;
        
        // Add force with direction to other object
    }

    private float CalculateForce()
    {
        // Calculate for belong to distance and mass of blackHold and other object G(m1*m2)/r*r
        return 0;
    }
}

[Serializable]
public struct BlackHoldConfig
{
    public List<ForceConfig> listForceConfigs;
}

[Serializable]
public struct ForceConfig
{
    public float range;
    public float force;
}
