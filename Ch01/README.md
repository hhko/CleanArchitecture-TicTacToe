# 기술 독립적인 `Tic Tac Toe` 프로젝트 만들기

## 솔루션 구성
```shell
# 솔루션 생성
dotnet new sln -n Ch01

# 프로젝트 생성
dotnet new classlib -o Ch01.Entities
dotnet new classlib -o Ch01.UseCases

# 단위 테스트 프로젝트 생성
dotnet new xunit -o Ch01.Entities.UnitTest
dotnet new xunit -o Ch01.UseCases.UnitTest

# 솔루션에 모든 프로젝트 추가
dotnet sln add (ls -r **\*.csproj)

# 빌드 & 테스트
dotnet build
dotnet test
```

## 초안 단위 테스트
1. 먼저 플레이를 시작하는 플레이어는 X이다.
1. 플레이어는 이미 채워진 공간에는 표시를 할 수 없다.
1. 플레이어 X가 빈 공간에 X 표시를 하면 이 공간은 더 이상 사용할 수 없다.
1. 플레이어 O가 플레이어 X가 표시를 한 후에 표시할 수 있다.
1. 플레이어는 존재하지 않는 공간에는 표시할 수 없다.
1. 이미 사용된 공간에 표시를 하려고 하면 에외가 발생한다.
1. 플레이어 X가 한 행에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
1. 플레이어 X가 한 열에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
1. 플레이어 X가 대각선으로 세 개의 X 표시를 모두 하면 플레이어 X가 승리한다.
1. 모든 공간이 채워지고 승자가 없으면 게임은 무승부가 된다.

## 최종 단위 테스트
1. TODO.