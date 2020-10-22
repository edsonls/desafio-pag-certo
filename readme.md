## Desafio PagCerto

#### Requesitos
  
- Docker
- Make

#### Instruções de Uso
Para rodar o projeto basta acessa a raiz e executar o comando `make deploy`, apos fazer isso o projeto vai estar rodando na porta 8088 com a interface do swagger.

#### SDK
Foi adicionado uma comando para gerar um container sdk afim de rodar migrations e os testes basta seguir o passo a passo.

##### Migration
(Windows PowerShell)P1.a:`docker run -d -ti -v ${PWD}:/app -w /app --net desafio-net --name sdk mcr.microsoft.com/dotnet/core/sdk:3.1`

(Linux)P1.b:`docker run -d -ti -v $PWD:/app -w /app --net desafio-net --name sdk mcr.microsoft.com/dotnet/core/sdk:3.1`

P2:`docker exec -it sdk bash`

P3:`export PATH="$PATH:/root/.dotnet/tools"`

P4:`dotnet tool install --global dotnet-ef`

P5:`cd DesafioPagCerto.Repositories/`

P6:`dotnet-ef database update`

##### Rodando os Tests

Basta Seguir os Passos P1, P2, P3, P4 ou aproveitar a sessão e realizar o P6 e P7

P6:`cd ../DesafioPagCerto.Tests/`

P7:`dotnet test --logger trx`