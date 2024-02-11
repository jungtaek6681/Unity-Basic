/********************************
 * 유니티 엔진의 동작 원리
 ********************************/

// <상속>
// 상속 : 부모클래스의 모든 속성과 기능들을 물려받는 자식클래스를 설계하는 방법
// 개발자는 상속을 통해 코드의 재사용, 계층구조를 이용한 유지보수, 코드의 추가 및 변경이 용이함
// 상속은 프로그램의 구성을 짜임새 있게 계층구조로 구성하는 방법
// 하지만 짜임새 있는 계층구조는 반대로 유연한 구조설계에 대처가 힘듬


// <컴포넌트>
// 컴포넌트 : 하나의 특정한 기능을 수행할 수 있도록 구성한 작은 기능단위
// 비어있는 게임오브젝트에 컴포넌트를 조립하여 게임 구성품을 만드는 방식
// 게임 엔진에서 유연한 구조설계를 하기 위해 컴포넌트 패턴을 사용함


// <메시지 브로드캐스팅>
// 유니티 엔진 입장에서 게임오브젝트의 컴포넌트 포함 여부를 파악한 뒤 기능을 실행시키는 것은 수행시간이 많이 필요
// 유니티 엔진은 컴포넌트의 특정 기능을 간접적으로 실행하는 메시지 방식을 사용
// 유니티 엔진은 게임오브젝트에 메시지를 전달하며 컴포넌트 중 메시지에 명시된 기능이 있다면 반응하며 없으면 무시함
// 이를 통해 컴포넌트의 포함 여부를 확인하고 기능을 실행하는 시간을 단축
// 메시지 브로드캐스팅 : 유니티 엔진이 모든 게임오브젝트를 대상으로 메시지를 전달하고 반응을 받지 않음
// 이를 통해 컴포넌트들이 다른 대상의 영향을 받지 않고 독립적으로 동작 가능


// <스크립트>
// 게임오브젝트의 동작은 연결된 컴포넌트에 의해 조절됨
// 유니티의 내장 컴포넌트들은 상당히 다수가 있으나 사용자를 위한 기능의 컴포넌트가 부족할 수 있음
// 유니티에서는 스크립트를 사용하여 사용자 정의 컴포넌트를 생성할 수 있음
// 유니티는 기본적으로 C# 프로그래밍 언어를 지원하며 C# 문법을 통해 컴포넌트의 기능을 구성 가능