using UnityEngine;

namespace Unity
{
    public class UnityTransform : MonoBehaviour
    {
        /****************************************************************************************
         * 트랜스폼 (Transform)
         * 
         * 게임오브젝트의 위치, 회전, 크기를 저장하는 컴포넌트
         * 게임오브젝트의 부모-자식 상태를 저장하는 컴포넌트
         * 게임오브젝트는 반드시 하나의 트랜스폼 컴포넌트를 가지고 있으며 추가 & 제거할 수 없음
         ****************************************************************************************/

        [SerializeField] Transform thisTransform;
        [SerializeField] Transform otherTransform;

        float moveSpeed = 3f;
        float rotateSpeed = 90f;

        // <트랜스폼 접근>
        // transform : 게임오브젝트에 있는 Transform 컴포넌트에 접근
        private void TransformReference()
        {
            thisTransform = transform;
        }

        // <트랜스폼 이동>
        // Translate : 트랜스폼 이동 함수
        private void Translate()
        {
            // 벡터를 이용한 이동
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // x, y, z를 이용한 이동
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);

            // position을 이용한 이동
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }


        // <트랜스폼 이동 공간>
        // 트랜스폼 이동의 기준을 설정
        private void TranslateSpace()
        {
            // 월드를 기준으로 이동
            transform.Translate(0, 0, 1, Space.World);
            // 로컬을 기준으로 이동
            transform.Translate(0, 0, 1, Space.Self);
            // 다른 대상을 기준으로 이동
            transform.Translate(0, 0, 1, otherTransform);
        }


        // <트랜스폼 회전>
        // Rotate : 트랜스폼 회전 함수
        private void Rotate()
        {
            // 축을 이용한 회전 (축을 기준으로 시계방향으로 회전)
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            // 오일러를 이용한 회전
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            // rotation을 이용한 회전
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }


        // <트랜스폼 회전 공간>
        // 트랜스폼 회전의 기준을 설정
        private void RotateSpace()
        {
            // 월드를 기준으로 회전
            transform.Rotate(0, 0, 1, Space.World);
            // 로컬을 기준으로 회전
            transform.Rotate(0, 0, 1, Space.Self);
            // 위치를 기준으로 회전
            transform.RotateAround(otherTransform.position, Vector3.up, 1);
        }


        // <트랜스폼 LookAt 회전>
        // LookAt : 위치를 바라보는 방향으로 회전
        private void LookAt()
        {
            // 위치를 바라보는 회전
            transform.LookAt(otherTransform.position);
        }


        // <Quaternion & Euler>
        // Quaternion : 3차원 방향을 저장하고 이를 방향에서 다른 방향으로의 상대 회전으로 정의
        //  장점 : 기하학적 회전으로 짐벌락 현상이 발생하지 않음
        //  단점 : 사원수를 이용한 방법으로 직관적이지 않음
        // EulerAngle : 3축을 기준으로 수치만큼 회전시키는 방법
        //  장점 : 직관적으로 계산가능
        //  단점 : 축에 의한 회전은 짐벌락 현상이 발생할 수 있음
        // 짐벌락 : 같은 방향으로 오브젝트의 두 회전 축이 겹치는 현상

        // Quaternion을 통해 회전각도를 계산하는 것은 직관적이지 않고 이해하기 어려움
        // 유니티의 경우 Quaternion과 Eular의 변환 함수를 지원하므로 필요에 따라 변환하여 사용
        private void Rotation()
        {
            Quaternion quaternion;
            Vector3 euler;

            // 트랜스폼의 회전값은 Euler 각도 표현이 아닌 Quaternion을 사용함
            quaternion = transform.rotation;

            // Euler를 Quaternion으로 변환
            euler = quaternion.eulerAngles;

            // Quaternion을 Euler로 변환
            quaternion = Quaternion.Euler(euler);
        }


        // <트랜스폼 부모-자식 관계>
        // 트랜스폼은 부모 트랜스폼을 가질 수 있음
        // 부모 트랜스폼이 있는 경우 부모 트랜스폼의 위치, 회전, 크기 변경이 같이 적용됨
        // 이를 이용하여 계층적 구조를 정의하는데 유용함 (ex. 어깨가 움직이면, 팔도 같이 움직임)
        // 하이어라키 창 상에서 드래그 & 드롭을 통해 부모-자식 상태를 변경할 수 있음
        private void TransformParent()
        {
            // 트랜스폼의 부모 설정
            transform.parent = otherTransform.parent;

            // 부모를 기준으로한 트랜스폼
            Vector3 localPosition = transform.localPosition;    // 부모트랜스폼이 있는 경우 부모를 기준으로 한 위치
            Quaternion localRotation = transform.localRotation; // 부모트랜스폼이 있는 경우 부모를 기준으로 한 회전
            Vector3 localScale = transform.localScale;          // 부모트랜스폼이 있는 경우 부모를 기준으로 한 크기

            // 트랜스폼의 부모가 null인 경우 월드를 기준
            transform.parent = null;

            // 월드를 기준으로한 트랜스폼
            Vector3 worldPosition = transform.position;         // 월드를 기준으로 한 위치
            Quaternion worldRotation = transform.rotation;      // 월드를 기준으로 한 회전
            // Vector3 worldScale = transform.localScale;       // 부모를 기준으로 한 크기
        }
    }
}