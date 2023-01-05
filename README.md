# 클린 아키텍처 도입기 Tic Tac Toe

<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Tic_tac_toe.svg/400px-Tic_tac_toe.svg.png" width=20%/>
https://en.wikipedia.org/wiki/Tic-tac-toe

## 프로젝트
- Part 1. 몸 풀기 코드
  - [ ] [Chapter 01. 클린 아키텍처 준비](./Ch01/)
  - [ ] Chapter 02. Strongly Typed Enum Pattern
  - [ ] Chapter 03. Value Object
  - [ ] Chapter 04. Entity
  - [ ] Chapter 05. Domain Service
  - [ ] Chapter 06. Use Case
- Part 2. 기술 독립적인 코드
  - [ ] [Chapter 07. 객체지향 Tic Tac Toe](./Ch06/)
  - [ ] Chapter 08. 함수형 Tic Tac Toe
  - [ ] Chapter 09. 메시지지향 Tic Tac Toe
- Part 3. 기술 의존적인 코드
  - [ ] Chapter 10. Repository Tic Tac Toe
  - [ ] Chapter 11. Web UI Tic Tac Toe
  - [ ] Chapter 12. Desktop UI Tic Tac Toe
  - [ ] Chapter 13. Hybrid UI(Web & Desktop UI) Tic Tac Toe

<br/>

## 기술 스택
- 기본
  - [x] [.NET 7.0 런타임](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
  - [x] [C# 11 언어](https://learn.microsoft.com/ko-kr/dotnet/csharp/whats-new/csharp-11)
- 설계
  - [x] [SmartEnum 패키지](https://github.com/ardalis/SmartEnum)
  - [ ] [MediatR 패키지](https://github.com/jbogard/MediatR)
  - [ ] [Ardalis.Result 패키지](https://github.com/ardalis/result)
  - [ ] [FluentValidation 패키지](https://github.com/FluentValidation/FluentValidation)
- 테스트 자동화
  - [x] [xUnit 패키지](https://github.com/xunit/xunit)
  - [x] [Fluent Assertions 패키지](https://github.com/fluentassertions/fluentassertions)
  - [ ] [NetArchTest 패키지](https://github.com/BenMorris/NetArchTest)
  - [ ] [AutoFixture 패키지](https://github.com/AutoFixture/AutoFixture)
  - [ ] [coverlet 패키지](https://github.com/coverlet-coverage/coverlet)
  - [ ] [ReportGenerator 패키지](https://github.com/danielpalme/ReportGenerator)
- CI/CD
  - [ ] GitHub Actions

<br/>

## 참고 자료
### 코드
- [ ] [Enterprise Tic-Tac-Toe with F#](https://fsharpforfunandprofit.com/posts/enterprise-tic-tac-toe/)
- [ ] [Tic-Tac-Toe WPF with F#](https://github.com/battermann/TicTacToe)
- [ ] [Console Tic-Tac-Toe](https://github.com/ZacharyPatten/dotnet-console-games/blob/main/Projects/Tic%20Tac%20Toe/Program.cs)
- [ ] [Tic-Tac-Toe WPF](https://github.com/gfoidl/TicTacToe)
- [ ] [Minimax AI Algorithm on Tic-Tac-Toe with C#](https://github.com/blaz-cerpnjak/tictactoe-minimax)
- [ ] [Minimax AI Algorithm on Tic-Tac-Toe with Python](https://github.com/Cledersonbc/tic-tac-toe-minimax)
- [ ] [Tic-Tac-Toe Game to demonstrate BDD](https://github.com/elbandit/Tic-Tac-Toe)
- [ ] [omid-ahmadpour/CleanArchitecture-Template](https://github.com/omid-ahmadpour/CleanArchitecture-Template)
- [ ] [dotnet-tic-tac-toe](https://github.com/madetech/dotnet-tic-tac-toe)
- [ ] [Using Blazor WebAssembly and C# to Build Tic-Tac-Toe in .NET Core](https://exceptionnotfound.net/using-blazor-webassembly-and-csharp-to-play-tic-tac-toe-in-dotnet-core/)
- [ ] [Domain-Driven-Design-Example](https://github.com/zkavtaskin/Domain-Driven-Design-Example)
- [ ] [Orleans TicTacToe web-based game](https://github.com/dotnet/samples/tree/main/orleans/TicTacToe)

### 영상
- [ ] 아키텍처 | [Brunch Architecture / if(kakao)2022](https://www.youtube.com/watch?v=CmABbuuxvn0)
- [ ] 아키텍처 | [기획자님들! 개발자가 아키텍처에 집착하는 이유, 쉽게 알려드립니다](https://www.youtube.com/watch?v=saxHxoUeeSw)
- [ ] DDD | [Domain Driven Design과 적용 사례공유](https://www.youtube.com/watch?v=4QHvTeeTsj0&list=PLwe9WEhzDhwHb4uC0WGHw0cU4gRDUt71X&index=47)
- [ ] DDD | [도메인 원정대](https://www.youtube.com/watch?v=kmUneexSxk0&t)
- [ ] DDD | [마이크로서비스 개발을 위한 Domain Driven Design](https://www.youtube.com/watch?v=QUMERCN3rZs&t)
- [ ] DDD | [공공 정보시스템을 위한 도메인 주도 설계 시작하기](https://www.youtube.com/watch?v=HmPp1TIjjbE)
- [ ] DDD | [Domain-Driven Design시작하기](https://www.youtube.com/watch?v=td5VRmxntmw&t)
- [ ] DDD | [Domain-Driven Design, Amichai Mantinband](https://www.youtube.com/watch?v=8Z5IAkWcnIw&list=PLzYkqgWkHPKDpXETRRsFv2F9ht6XdAF3v)
- [ ] 아키텍처 | [ASP.NET 6 REST API Following CLEAN ARCHITECTURE & DDD Tutorial, Amichai Mantinband](https://www.youtube.com/watch?v=fhM0V2N1GpY&list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k)
- [ ] 아키텍처 | [클린 아키텍처 애매한 부분 정해 드립니다.](https://forward.nhn.com/2022/sessions/24)
- [ ] 아키텍처 | [Dooray! 모바일 앱의 클린 아키텍처 적용기](https://forward.nhn.com/2022/sessions/27)
- [ ] DDD | [DDD 뭣이 중헌디?](https://forward.nhn.com/2022/sessions/38)
- [ ] Enum | [How To Create Smart Enums in C# With Rich Behavior](https://www.youtube.com/watch?v=v6cYTcEfZ8A)

### 도서
- [ ] [클린 아키텍처 ](http://www.yes24.com/Product/Goods/77283734)
- [ ] [도메인 주도 설계](http://www.yes24.com/Product/Goods/5312881)
- [ ] [도메인 주도 설계 철저 입문](http://www.yes24.com/Product/Goods/93384475)
- [ ] [도메인 주도 설계 첫걸음](http://www.yes24.com/Product/Goods/109708596)
- [ ] [도메인 주도 설계 구현 ](http://www.yes24.com/Product/Goods/25100510)
- [ ] [만들면서 배우는 클린 아키텍처](http://www.yes24.com/Product/Goods/105138479)
- [ ] [만들면서 배우는 헥사고날 아키텍처 설계와 구현](http://www.yes24.com/Product/Goods/112927162)
- [ ] [단위 테스트](http://www.yes24.com/Product/Goods/104084175)

### 문서
- [ ] 아키텍처 | [클린 아키텍쳐 — 소스 코드 구조는 어떻게?](https://justwrite99.medium.com/%ED%81%B4%EB%A6%B0-%EC%95%84%ED%82%A4%ED%85%8D%EC%B3%90-%EC%86%8C%EC%8A%A4-%EC%BD%94%EB%93%9C-%EA%B5%AC%EC%A1%B0%EB%8A%94-%EC%96%B4%EB%96%BB%EA%B2%8C-90b872745b41)
- [ ] 아키텍처 | [클린 코드 — Cleaning Code to Domain Model](https://justwrite99.medium.com/%ED%81%B4%EB%A6%B0-%EC%BD%94%EB%93%9C-cleaning-code-to-domain-model-eed66a83c0e5)
- [ ] 아키텍처 | [Clean Architecture : Part 1 — Database vs Domain](https://justwrite99.medium.com/%ED%81%B4%EB%A6%B0-%EC%95%84%ED%82%A4%ED%85%8D%EC%B2%98-%ED%8C%8C%ED%8A%B81-%EB%8D%B0%EC%9D%B4%ED%84%B0%EB%B2%A0%EC%9D%B4%EC%8A%A4-vs-%EB%8F%84%EB%A9%94%EC%9D%B8-236c7008ac83)
- [ ] 아키텍처 | [Clean Architecture : Part 2 — The Clean Architecture](https://justwrite99.medium.com/clean-architecture-part-2-the-clean-architecture-3e2666cdce83)
- [ ] 아키텍처 | [클린 아키텍처 by 엉클 밥](https://justwrite99.medium.com/%ED%81%B4%EB%A6%B0-%EC%95%84%ED%82%A4%ED%85%8D%EC%B2%98-by-%EC%97%89%ED%81%B4-%EB%B0%A5-a6a917ff6afc)
- [ ] 아키텍처 | [Clean architecture series— Part 1](https://pereiren.medium.com/clean-architecture-series-part-1-f34ef6b04b62)
- [ ] 아키텍처 | [Clean architecture series— Part 2](https://pereiren.medium.com/clean-architecture-series-part-2-56197c4b9d58)
- [ ] 아키텍처 | [Clean architecture series— Part 3](https://pereiren.medium.com/clean-architecture-series-part-3-a0c150551e5f)
- [ ] Enum | [Enum Alternatives in C#](https://ardalis.com/enum-alternatives-in-c/)
- [ ] Enum | [How to implement a type-safe enum pattern in C#](https://www.infoworld.com/article/3198453/how-to-implement-a-type-safe-enum-pattern-in-c.html)
- [ ] 알고리즘 | [Algorithm to Detect A tic tac toe Winner](https://jayeshkawli.ghost.io/tic-tac-toe/)
