using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderCallReceiver : MonoBehaviour
{
    public class TriggerEvent : UnityEvent<Collider> { }
    public TriggerEvent TriggerEnterEvent = new TriggerEvent();
    public TriggerEvent TriggerStayEvent = new TriggerEvent();
    public TriggerEvent TriggerExitEvent = new TriggerEvent();
    private void OnTriggerEnter(Collider other)
    {
        TriggerEnterEvent?.Invoke(other);
    }
    private void OnTriggerStay(Collider other)
    {
        TriggerStayEvent?.Invoke(other);
    }
    private  void OnTriggerExit(Collider other)
    {
        TriggerExitEvent?.Invoke(other);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
