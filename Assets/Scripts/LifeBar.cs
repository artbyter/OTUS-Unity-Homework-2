using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    [SerializeField] Transform lifeBar;
    Health health;
    float fullHealth;
    float displayedHealth;
    // Start is called before the first frame update
    void Start()
    {
        
        health = GetComponentInParent<Health>();
        fullHealth = health.current;
        displayedHealth = health.current ;
        gameObject.transform.localScale = new Vector3(fullHealth / 4, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(!Mathf.Approximately(displayedHealth,health.current))
        {
            displayedHealth = health.current;
            
            lifeBar.localScale = new Vector3(displayedHealth/fullHealth, lifeBar.localScale.y, lifeBar.localScale.z);
            
        }
            
    }
}
