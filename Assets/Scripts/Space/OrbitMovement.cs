using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    [SerializeField] private Transform orbitingObject;
    [SerializeField] internal Orbit orbitPath = new Orbit(10, 10);
    [Range(0f,1f)]
    [SerializeField] internal float orbitProgress = 0f;
    [SerializeField] internal float orbitPeriod = 3f;
    [SerializeField] internal bool orbitActive = true;
    [SerializeField] internal bool toOptimize = false;

    private Vector2 _tempOrbitPosition2D;
    private Vector3 _tempOrbitPosition3D;

    void Start()
    {
        if(orbitingObject == null)
        {
            orbitActive = false;
            return;
        }

        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

    void SetOrbitingObjectPosition()
    {
        _tempOrbitPosition2D = orbitPath.Evaluate(orbitProgress);
        _tempOrbitPosition3D.Set(_tempOrbitPosition2D.x, 0, _tempOrbitPosition2D.y);

        orbitingObject.localPosition = _tempOrbitPosition3D;
    }

    IEnumerator AnimateOrbit()
    {
        if(orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }

        float orbitSpeed = 1f / orbitPeriod;

        while (orbitActive)
        {
            if (GameState.onPause != true)
            {
                orbitProgress += Time.deltaTime * orbitSpeed;
                orbitProgress %= 1f;
                SetOrbitingObjectPosition();
            }
            
            yield return null;
        }
    }
}