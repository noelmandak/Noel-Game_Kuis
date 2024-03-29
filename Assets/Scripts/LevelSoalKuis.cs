using UnityEngine;

[CreateAssetMenu(
    fileName = "Soal Baru",
    menuName = "Game Kuis/Leval Soal Kuis")]
public class LevelSoalKuis : ScriptableObject
{
    [System.Serializable]
    public struct OpsiJawaban
    {
        public string jawabanTeks;
        public bool adalahBenar;   
    }
    public string pertanyaan;
    public Sprite petunjukJawaban;
    
    public OpsiJawaban[] opsiJawaban = new OpsiJawaban[0];
}
