using UnityEngine;

namespace Unity
{
    public class UnityUI : MonoBehaviour
    {
        /****************************************************************************
         * 사용자 인터페이스 (User Interface)
         * 
         * 유저가 프로그램과 의사소통을 할 수 있도록 만든 매개체
         * 버튼, 이미지, 텍스트 등 소프트웨어적으로 유니티와 의사소통 할 수 있는 수단
         *****************************************************************************/

        // <캔버스>
        // UI 요소들을 가지고 있는 UI 구성틀
        // 모든 UI 요소들은 캔버스 안에 위치해야 함
        // 위치가 겹칠 경우 나중에 그려지는 UI 요소가 이전 UI 요소를 덮어씀


        // <RenderMode>
        // UI가 화면에 표현하거나 3D 공간에 게임오브젝트로 표현하는 방법을 정의
        // Screen Space - Overlay : UI를 별도의 공간에 위치시키며 화면을 그릴 때 합성하여 표현
        // Screen Space - Camera : UI를 카메라 앞 평면에 위치시켜 표현
        // World Space : UI를 게임오브젝트와 같은 공간에 위치시켜 표현


        // <Canvas Scaler>
        // 캔버스 내 UI 요소의 전체적인 크기와 비율을 제어하는 데 사용
        // Constant Pixel Size : UI 요소가 화면 크기에 관계없이 동일한 픽셀 크기로 유지
        // Scale With Screen Size : UI 요소가 화면 크기에 따라 동일한 비율을 유지
        // Constant Physical Size : UI 요소가 화면 크기에 관계없이 동일한 물리적인 크기로 유지


        // <Event System>
        // 키보드, 마우스, 터치, 등을 게임오브젝트에 이벤트를 전송하는 방법
        // Event System이 씬에 없는 경우 UI가 반응하지 않으니 주의
    }
}