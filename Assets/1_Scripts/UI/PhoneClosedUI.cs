using TMPro;
using UnityEngine;

namespace UI
{
    public class PhoneClosedUI : MonoBehaviour
    {
        [SerializeField] private GameObject notificationPin; 
        private TextMeshProUGUI _notificationPinText;

        private short _notificationCount;

        private void Awake()
        {
            _notificationPinText = notificationPin.GetComponentInChildren<TextMeshProUGUI>();
            ResetNotificationCount();
        }

        public void IncreaseNotificationCount()
        {
            notificationPin.SetActive(true);
            _notificationCount++;
            _notificationPinText.text = _notificationCount.ToString();
        }

        public void ResetNotificationCount()
        {
            notificationPin.SetActive(false);
            _notificationCount = 0;
        }
    }
}