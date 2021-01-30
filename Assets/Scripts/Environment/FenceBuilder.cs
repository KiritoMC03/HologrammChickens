using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceBuilder : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int length;
    [SerializeField] private Transform[] fencePrefabs;
    [SerializeField] private float fenceLength = 0.363f;
    [SerializeField] private Quaternion rotate = Quaternion.Euler(-90,0,0);

    private Transform _transform;
    private int perimeter = 0;
    private int fencePrefabsCount;
    private int random = 0;
    private Vector3 nextPosition = Vector3.zero;

    private void Awake()
    {
        _transform = transform;
        perimeter = (width + length) * 2;
        fencePrefabsCount = fencePrefabs.Length;
    }

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (i < width && j == 0) // первая строка
                {
                    nextPosition.Set(0, 0, fenceLength * i);
                    rotate = Quaternion.Euler(-90, 90, 0);
                }
                else if (i == 0 && j < length) // левая колонка
                {
                    nextPosition.Set(fenceLength * j, 0, 0);
                    rotate = Quaternion.Euler(-90, 0, 0);
                }
                else if (j == length - 1 && i < width) // правая колонка
                {
                    nextPosition.Set(fenceLength * j, 0, fenceLength * i);
                    rotate = Quaternion.Euler(-90, 90, 0);
                }
                else if (j < length && i == width - 1) // последняя строка
                {
                    nextPosition.Set(fenceLength * j, 0, fenceLength * i);
                    rotate = Quaternion.Euler(-90, 0, 0);
                }
                else
                {
                    continue;
                }

                random = UnityEngine.Random.Range(0, fencePrefabsCount);
                Instantiate(fencePrefabs[random], _transform.position + nextPosition, rotate);
            }
        }
    }

    private void BuildSide(Vector3 startPosition, Vector3 nextPosition)
    {
    }
}
