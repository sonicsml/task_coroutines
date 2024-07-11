using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay;
    
    private Coroutine _coroutineCounter;
    private int _timer = 0;

    private void Start()
    {
            _text.text = "";
            Restart();
    }

    private void Stop()
    {

        if (_coroutineCounter != null)
            StopCoroutine(_coroutineCounter);
    }

    private void Restart()
    {
        _coroutineCounter = StartCoroutine(SwitcthTimer(_delay));
    }

    private IEnumerator SwitcthTimer(float delay)
    {
        var wait = new WaitForSeconds(delay);
        
        while (enabled)
        {
            DisplayTimerUp(_timer++);
            yield return wait;
        }
    }

    private void DisplayTimerUp (int count)
    {
        _text.text = count.ToString("");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (_text.enabled = !_text.enabled))
        {
            Restart();
        }
        else if (Input.GetMouseButtonDown(0) && (_text.enabled == _text.enabled)) {
            Stop();
        }
    }
}
