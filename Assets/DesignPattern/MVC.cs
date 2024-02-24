/****************************************************
 *                 디자인 패턴 MVC                  *
 ****************************************************/

/*
 * <MVC (Model-View-Controller) 패턴>
 * 사용자 인터페이스, 데이터, 로직을 분리하여 프로그램을 관리하는 패턴
 * 
 * <구현>
 * Model
 *  프로그램의 데이터
 *  Controller에 의해 갱신
 *  데이터의 변경을 View에게 알림
 * View
 *  사용자 인터페이스
 *  Model의 데이터를 기반으로 사용자에게 내용 표현
 *  사용자에게 입력을 받아 Controller에게 알림
 * Controller
 *  로직
 *  View의 입력을 받아 논리로직을 처리
 *  논리로직의 결과를 Model에 갱신
 * 
 * <장점>
 * 1. 설계패턴 중 가장 단순하게 구현가능
 * 2. 프로그램의 구성 요소를 영향없이 쉽게 고칠 수 있도록 제안
 * 3. 유지보수성, 어플리케이션의 확장성, 유연성과 코드재사용성이 좋아짐
 * 
 * <주의점>
 * 1. Model과 View 사이의 의존성을 갖지 않도록 주의
 * 
 * <그 외>
 * MVC 패턴의 파생형인 MVP(Model-View-Presenter), MVVM(Model-View-ViewModel) 패턴이 있음
 */

using UnityEngine;
using UnityEngine.Events;

namespace DesignPattern
{
    public class Model
    {
        private int data;
        public int Data
        {
            set
            {
                Debug.Log("[Model] Change data");
                data = value;
                OnDataChanged?.Invoke(value);
            }
            get
            {
                return data;
            }
        }

        public UnityAction<int> OnDataChanged;
    }

    public class View
    {
        public Controller controller;

        public void UpdateData(int data)
        {
            Debug.Log("[View] Update data");
        }

        public void Input()
        {
            Debug.Log("[View] Input");
            controller.Logic();
        }
    }

    public class Controller
    {
        public Model model;

        public void Logic()
        {
            Debug.Log("[Controller] Logic");
            model.Data += 1;
        }
    }

    public class MVCTester
    {
        public void Test()
        {
            Model model = new Model();
            View view = new View();
            Controller controller = new Controller();

            view.controller = controller;
            controller.model = model;
            model.OnDataChanged += view.UpdateData;

            view.Input();
            // 1. [View] Input
            // 2. [Controller] Logic
            // 3. [Model] Change data
            // 4. [View] Update data
        }
    }
}