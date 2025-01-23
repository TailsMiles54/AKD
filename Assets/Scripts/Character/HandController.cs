using UnityEngine;

namespace Character
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _maxDistance = 1.4f;
    
        private GameObject _itemInHand;

        public void InteractWithItem()
        {
            if (_itemInHand == null)
            {
                _itemInHand = TryGetItem();
                if (_itemInHand != null)
                {
                    _itemInHand.transform.parent = transform;
                    _itemInHand.GetComponent<BoxCollider>().enabled = false;
                    _itemInHand.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
            else
            {
                _itemInHand.transform.parent = null;
                _itemInHand.GetComponent<Rigidbody>().isKinematic = false;
                _itemInHand.GetComponent<Rigidbody>().useGravity = true;
                _itemInHand.GetComponent<BoxCollider>().enabled = true;
            }
        }
    
        private GameObject TryGetItem()
        {
            Vector3 origin = _camera.transform.position;
            Vector3 direction = _camera.transform.forward;

            if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, _maxDistance))
            {
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Объект с тегом 'Item' найден!");
                    return hitInfo.transform.gameObject;
                }
                Debug.Log($"Объект не является 'Item'. Tag = {hitInfo.transform.name}");
            }
            else
            {
                Debug.Log("Ничего не найдено на расстоянии " + _maxDistance);
            }

            return null;
        }
    }
}