using UnityEngine;
using TMPro;

public class UI_PoinJawaban : MonoBehaviour
{
    [SerializeField]
    private UI_PesanLevel _textPesan = null;
    
    [SerializeField]
    private TextMeshProUGUI _textJawaban = null;
    
    [SerializeField]
    private bool _adalahBenar = false;

    public void PilihJawaban()
    {
        Debug.Log($"{_textJawaban.text} adalah {_adalahBenar}");
        _textPesan.Pesan = $"{_textJawaban.text} adalah {_adalahBenar}";
    }

    public void SetJawaban(string textJawaban, bool adalahBenar)
    {
        _textJawaban.text = textJawaban;
        _adalahBenar = adalahBenar;
    }
}
