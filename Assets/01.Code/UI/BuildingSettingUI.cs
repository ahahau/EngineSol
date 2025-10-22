using UnityEngine;

namespace _01.Code.UI
{
    public class BuildingSettingUI : MonoBehaviour
    {
        [SerializeField] private GameObject ui;
        public void Open()
        {
            ui.SetActive(true);
        }
        public void Close()
        {
            ui.SetActive(false);
        }
    }
}