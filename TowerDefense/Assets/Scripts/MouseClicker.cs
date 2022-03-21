using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicker : MonoBehaviour
{
    private Camera _mainCam;


    public static event Action<GameObject> EnemyHit;
        // Start is called before the first frame update
        void Start()
    {
        _mainCam = GetComponent<Camera>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    EnemyHit?.Invoke(hitInfo.collider.gameObject);
                    Debug.Log("Hit me!!");

                }
            }
        }
    }
    


}
