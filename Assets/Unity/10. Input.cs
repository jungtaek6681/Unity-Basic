using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity
{
    public class UnityInput : MonoBehaviour
    {
        /***************************************************************************
         * 유니티 입력
         * 
         * 유니티에서 사용자의 명령을 감지할 수 있는 수단
         * 사용자는 외부 장치를 이용하여 게임을 제어할 수 있음
         * 유니티는 다양한 타입의 입력기기(키보드 및 마우스, 조이스틱, 등)를 지원)
         ***************************************************************************/

        // <Device>
        // 특정한 장치를 기준으로 입력 감지
        // 특정한 장치의 입력을 감지하기 때문에 여러 플랫폼에 대응이 어려움
        private void InputByDevice()
        {
            // 키보드 입력감지
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Space key is perssing");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key is down");
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("Space key is up");
            }

            // 마우스 입력감지
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Mouse left button is pressing");
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse left button is down");
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Mouse left button is up");
            }
        }


        // <InputManager>
        // 여러 장치의 입력을 입력매니저에 이름과 입력을 정의
        // 입력매니저의 이름으로 정의한 입력의 변경사항을 확인
        // 유니티 에디터의 Edit -> Project Settings -> Input Manager 에서 관리
        // 단, 유니티 초창기의 방식이기 때문에 키보드, 마우스, 조이스틱에 대한 장치만을 고려함
        private void InputByInputManager()
        {
            // 버튼 입력
            // Fire1 : 키보드(Left ctrl), 마우스(Left button), 조이스틱(Button0)으로 정의함
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("Fire1 is pressing");
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Fire1 is down");
            }
            if (Input.GetButtonUp("Fire1"))
            {
                Debug.Log("Fire1 is up");
            }

            // 축 입력
            // Horizontal(수평) : 키보드(a,d / ←,→), 조이스틱(왼쪽 아날로그스틱 좌우)
            float x = Input.GetAxis("Horizontal");
            if (x != 0)
            {
                Debug.Log($"Horizontal Axis {x}");
            }
            // Vertical(수직) : 키보드(w,s / ↑,↓), 조이스틱(왼쪽 아날로그스틱 상하)
            float y = Input.GetAxis("Vertical");
            if (y != 0)
            {
                Debug.Log($"Vertical Axis {y}");
            }
        }


        // <InputSystem>
        // InputSystem 패키지를 이용한 입력방식
        // 컴포넌트를 통해 입력의 변경사항을 확인
        // 최신에 지원한 방식으로 다양한 기기를 지원
        private void OnFire(InputValue value)
        {
            // Fire 버튼 입력에 반응하는 OnFire 메시지 함수
            bool input = value.isPressed;
            Debug.Log($"OnFire input {input}");
        }

        private void OnMove(InputValue value)
        {
            // Move 축 입력에 반응하는 OnMove 메시지 함수
            Vector2 input = value.Get<Vector2>();
            Debug.Log($"OnMove input {input}");
        }
    }
}