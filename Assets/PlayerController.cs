using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int Health = 10;
    public Slider zapperSlider;
    public Light lightSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health--;
        if (Health > 0)
        {
            Debug.Log(string.Format("Player was hit and has {0} health remaining.", Health));
        }
        else
        {
            Debug.Log("Game over.");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!charging && Input.GetKeyDown(KeyCode.Space))
        {
            charging = true;
        }

        if (charging)
        {
            zapperSlider.value += Time.deltaTime / ChargeTimeInSeconds;
            lightSource.intensity += Time.deltaTime / ChargeTimeInSeconds;
        }

        if (zapperSlider.value >= zapperSlider.maxValue)
        {
            charging = false;
            Zap();
            zapperSlider.value = 0;
            lightSource.intensity = 0;
        }
    }

    private void Zap()
    {
        Debug.Log("Zap!");
    }

    private const int ChargeTimeInSeconds = 2;
    private bool charging = false;
}
