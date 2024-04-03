using System.Collections;
using TMPro;
using UnityEngine;

public class TimerSwitch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private bool _isActive = true;
    private int _time = 0;

    private void Start()
    {
        _text.text = _time.ToString("");
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _isActive = !_isActive;
            StartCoroutine(Countdown(0.5f, _time));
        }
    }

    private IEnumerator Countdown(float delay, int time)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            time++;
            _time = time;
            DisplayCountdown(time);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }
}
