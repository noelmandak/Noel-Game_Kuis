using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tempatText = null;
    
    [SerializeField]
    private Image _tematGambar = null;

    public float waktu = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_tempatText.text);
    }

    public void SetPertanyaan(string textPertanyaan, Sprite gambarHint)
    {
        _tempatText.text = textPertanyaan;
        _tematGambar.sprite = gambarHint;
    }
}
