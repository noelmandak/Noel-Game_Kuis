using UnityEngine;
using UnityEngine.UI;

public class UI_Timmer : MonoBehaviour
{
    [SerializeField]
    private UI_PesanLevel _tempatPesan = null;

    [SerializeField]
    private Slider _timeBar = null;

    [SerializeField]
    private float _waktuJawab = 30f;
    private float _sisaWaktu = 0f;
    private bool _waktuBerjalan = true;

    public bool WaktuBerjalan
    {
        get => _waktuBerjalan;
        set => _waktuBerjalan = value;
    }

    void Start()
    {
        UlangWaktu();
    }

    public void UlangWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }

    void Update()
    {
        if (!_waktuBerjalan)
            return;

        _sisaWaktu -= Time.deltaTime;
        _timeBar.value = _sisaWaktu / _waktuJawab;

        if (_sisaWaktu <= 0f)
        {
            // Debug.Log("Waktu Habis");
            _tempatPesan.Pesan = "Waktu Sudah Habis !!!";
            _tempatPesan.gameObject.SetActive(true);
            _waktuBerjalan = false;
            return;
        }
        // Debug.Log(_sisaWaktu);
    }
}
