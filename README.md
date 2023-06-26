# Documentação do Projeto Viajá

## Visão Geral

O Viajá é um projeto de planejamento de viagens que visa facilitar a organização e a reserva de viagens para os usuários. Ele é desenvolvido usando a tecnologia .NET para a API, React JS para o frontend e SQL Server como banco de dados. O projeto é configurado e executado usando o Docker Compose, que facilita a implantação e o gerenciamento das diferentes partes do aplicativo.

## Pré-requisitos

Antes de começar a configurar e executar o projeto Viajá, é necessário ter os seguintes pré-requisitos instalados em seu ambiente de desenvolvimento:

1. [Node.js](https://nodejs.org) - Versão 14.x ou superior.
2. [.NET SDK](https://dotnet.microsoft.com/download) - Versão 5.x ou superior.
3. [Docker](https://www.docker.com/get-started) - Versão 20.x ou superior.
4. [Docker Compose](https://docs.docker.com/compose/install) - Versão 1.29.x ou superior.
5. [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) - Instalado e configurado.

## Configuração do Projeto

Siga as etapas abaixo para configurar o projeto Viajá em seu ambiente:

1. Clone o repositório do projeto via Git:

   ```
   git clone https://github.com/gabrieldamke/TravelTDS_API/
   ```

2. Navegue até o diretório raiz do projeto:

   ```
   cd Viaja
   ```

3. API - Configuração

   a. Navegue até o diretório da API:

      ```
      cd Viaja.API
      ```

   b. Abra o arquivo `appsettings.json` e atualize a string de conexão do banco de dados SQL Server de acordo com suas configurações:

      ```json
      "ConnectionStrings": {
        "DefaultConnection": "Server=<NOME_DO_SERVIDOR>;Database=<NOME_DO_BANCO>;User Id=<USUÁRIO>;Password=<SENHA>;"
      }
      ```

   c. Execute o seguinte comando para restaurar as dependências da API:

      ```
      dotnet restore
      ```

   d. Execute o seguinte comando para aplicar as migrações e criar as tabelas no banco de dados:

      ```
      dotnet ef database update
      ```

   e. Inicie a API:

      ```
      dotnet run
      ```

   A API agora está sendo executada em `http://localhost:5000`.

4. Frontend - Configuração

   a. Navegue até o diretório do frontend:

      ```
      cd Viaja.Client
      ```

   b. Execute o seguinte comando para instalar as dependências do frontend:

      ```
      npm install
      ```

   c. Abra o arquivo `.env` e verifique se a variável `REACT_APP_API_URL` está configurada corretamente para apontar para a URL da API (por padrão, `http://localhost:5000`):

      ```
      REACT_APP_API_URL=http://localhost:5000
      ```

   d. Inicie o aplicativo frontend:

      ```
      npm start
      ```

   O aplicativo frontend agora está sendo executado em `http://localhost:3000`.

5. Docker Compose - Configuração

   a. Volte para o diretório raiz do projeto:



      ```
      cd ..
      ```

   b. Crie e inicie os contêineres do Docker usando o Docker Compose:

      ```
      docker-compose up -d
      ```

   O Docker Compose criará e iniciará os contêineres para a API, frontend e SQL Server.

6. Acesso ao Aplicativo

   Agora você pode acessar o aplicativo Viajá em seu navegador em `http://localhost:3000`. Você poderá planejar e reservar suas viagens usando a interface do aplicativo.

## Conclusão

O projeto Viajá é uma solução de planejamento de viagens que utiliza tecnologias modernas, como .NET para a API, React JS para o frontend e SQL Server como banco de dados. Com a configuração e execução adequadas do Docker Compose, você pode implantar facilmente o aplicativo em seu ambiente de desenvolvimento. Sinta-se à vontade para explorar e personalizar o projeto de acordo com suas necessidades.
