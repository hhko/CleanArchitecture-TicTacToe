# Chapter 00. 클린 아키텍처 준비

## 주요 개념
1. **분리**
   - `기술 독립적인 코드(Entities)`와 `기술 의존적인 코드(Adapters)`를 분리한다.
     - 기술 독립적인 코드란?  
       비즈니스 요구사항을 구현하기 위해 `프로그래밍 언어`에만 의존하는 코드
     - 기술 의존적인 코드란?  
       비즈니스 요구사항을 동작시키 위해 `구체적인 기술`에 의존하는 코드
1. **통합**
   - 기술 독립적인 코드와 기술 의존적인 코드를 `유스 케이스(Use Cases)`로 공통분모를 만든다.
   - 유스 케이스란란?
     - 기술 의존적인 코드와 통합하기 위해 인터페이스(Port)가 정의된 `기술 독립적인 코드`다.
     - 사용자가 요구하여 시스템이 수행하는 입/출력이 있는 `하나의 사용 시나리오`(인식가능한 기능 단위)이다.
     ```
     A use case corresponds to a set of behaviors 
         that the system may perform in interaction with its actors, 
         and which produces an observable result 
         that contributes to its goals. 
     Actors represent the role 
         that human users or other systems have in the interaction.
     ```
1. **중심**
   - 3. 기술 의존적인 코드 > 2. 유스 케이스 > 1. 기술 독립적인 코드
1. **의존성 방향**
   - 기술 의존적인 코드(Adapters : 입력) `→` 유스 케이스 `→` 기술 독립적인 코드(Entities)
   - 기술 의존적인 코드(Adapters : 출력) `→` 유스 케이스 `→` 기술 독립적인 코드(Entities)
1. **제어 흐름(의존성 역전)**
   - 기술 의존적인 코드(Adapters : 입력) `→` 유스 케이스 `→` 기술 독립적인 코드
   - 기술 의존적인 코드(Adapters : 출력) `←(의존성 역전)` 유스 케이스 `→` 기술 독립적인 코드

## 레이어 용어
- 기술 의존적인 코드 : `Adapter`
  - 입력 인터페이스(Port) 구현 클래스 : `Input Adapter`
  - 출력 인터페이스(Port) 구현 클래스 : `Output Adapter`
- 유스 케이스 : `Use Cases`
  - 기술 의존적인 코드의 입력 인터페이스 : `Input Port`
  - 기술 의존적인 코드의 출력 인터페이스 : `Output Port`
  - 사용 시나리오
- 기술 독립적인 코드 : `Entities`
  - 동일성(identity) : `Entity`
  - 동등성(equality) : `Value Object`
  - `Domain Service`

## 참고 자료
- [Use code coverage for unit testing](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)
- [유스 케이스 wiki](https://ko.wikipedia.org/wiki/%EC%9C%A0%EC%8A%A4_%EC%BC%80%EC%9D%B4%EC%8A%A4)
- [Use Case wiki](https://en.wikipedia.org/wiki/Use_case)