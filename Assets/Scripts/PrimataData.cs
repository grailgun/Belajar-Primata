using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Primata")]
public class PrimataData : ScriptableObject
{
    [SerializeField] Sprite gambar;
    [SerializeField] string nama;

    [TextArea(3, 5)]
    [SerializeField] string deskripsi;

    public string PrimataName => nama;

    public string[] pertanyaan;
}
