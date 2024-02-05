using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NorskaLib.Spreadsheets;
using System;
using NorskaLibExamples.Spreadsheets;

namespace NorskaLibExamples.Spreadsheets
{
    [Serializable]
    public class SpreadshetContent
    {
        [SpreadsheetPage("Character")]
        public String Character;
        [SpreadsheetPage("Guns")]
        public string guns;
        [SpreadsheetPage("Damage")]
        public int damage;
    }

}
[CreateAssetMenu(fileName = "SpreadsheetContainer", menuName = "SpreadsheetContainer")]
public class SpreadSheets : SpreadsheetsContainerBase
{
    [SpreadsheetContent]
    [SerializeField] SpreadshetContent content;
    public SpreadshetContent Content => content;
}