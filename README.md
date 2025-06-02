# Meu Primeiro Projeto C# com AngularJS

Este é um projeto de API Web desenvolvido em C# usando ASP.NET Core. Este README explica a estrutura e funcionamento do projeto de forma didática.

## Entendendo as Tecnologias

### C#, .NET e ASP.NET Core: Qual a Diferença?

1. **C# (C Sharp)**
   - É a **linguagem de programação** que você está usando
   - É como o português que você usa para escrever
   - Exemplo de código C#:
   ```csharp
   public class Usuario
   {
       public string Nome { get; set; }
   }
   ```

2. **.NET 9**
   - É a **plataforma** onde seu código C# vai rodar
   - É como o "motor" que executa seu código
   - Fornece todas as ferramentas básicas que você precisa
   - Exemplo: quando você escreve `Console.WriteLine()`, isso vem do .NET

3. **ASP.NET Core**
   - É um **framework** específico para criar aplicações web
   - É como um "conjunto de ferramentas" especial para web
   - Vem dentro do .NET
   - Exemplo: quando você usa `app.MapGet()`, isso vem do ASP.NET Core

### Analogia com um Carro
```
C# = A linguagem que você usa para dar instruções
.NET = O motor do carro
ASP.NET Core = O sistema de direção e controles do carro
```

### Exemplo Prático
```csharp
// C#: A linguagem que você está usando
public class UsuarioController
{
    // ASP.NET Core: O framework que fornece [HttpGet]
    [HttpGet]
    public IActionResult GetUsuarios()
    {
        // .NET: Fornece List<T> e outras funcionalidades básicas
        var usuarios = new List<Usuario>();
        return Ok(usuarios);
    }
}
```

### Como Funciona no Projeto
1. Você escreve código em **C#**
2. O código roda na plataforma **.NET 9**
3. Usa **ASP.NET Core** para criar a API web

É como se:
- **C#** fosse o português que você fala
- **.NET** fosse o Brasil onde você vive
- **ASP.NET Core** fosse a cidade específica onde você mora

## O que é uma API Web?

Uma API Web é como um garçom em um restaurante:
- O cliente (outro programa) faz pedidos (requisições)
- A API (garçom) processa esses pedidos e retorna respostas
- Por exemplo: quando você usa um aplicativo de banco, ele se comunica com uma API do banco

## Estrutura do Projeto

```
MeuPrimeiroProjetoCSharp/
├── Controllers/    (Salas de controle)
├── Models/         (Móveis/Objetos)
├── Program.cs      (Planta da casa)
└── appsettings.json (Configurações da casa)
```

## Componentes do Projeto

### 1. Models (Modelos)
- São como "formulários" que definem como os dados devem ser
- Exemplo da classe `Usuario`:
```csharp
public class Usuario
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
}
```

### 2. Controllers (Controladores)
- São como "recepcionistas" que recebem as requisições
- Decidem o que fazer com cada pedido
- Exemplos de funções:
  - Listar usuários
  - Criar novo usuário
  - Atualizar dados de usuário

### 3. Program.cs
- É o "cérebro" da aplicação
- Configura tudo o que a aplicação precisa
- Define como a aplicação deve funcionar
- Configurações importantes:
  - HTTPS (conexão segura)
  - Tratamento de erros
  - Funcionalidades ativas

### 4. appsettings.json
- É como um "manual de configurações"
- Armazena informações como:
  - Conexão com banco de dados
  - Chaves de segurança
  - Configurações específicas do ambiente

## Como Funciona na Prática

1. Cliente faz uma requisição (ex: "mostre todos os usuários")
2. Controller recebe a requisição
3. Controller usa os Models para entender os dados
4. Controller processa a requisição
5. Controller retorna uma resposta

## Ferramentas Incluídas

### Swagger
- Funciona como um "manual" da API
- Mostra todos os endpoints disponíveis
- Permite testar a API diretamente pelo navegador
- Ajuda outros desenvolvedores a entenderem como usar a API

## Segurança

- **HTTPS**: Garante comunicações seguras
- **Autorização**: Controla quem pode acessar o quê
- **Validação de dados**: Garante que os dados estejam corretos

## Exemplo Prático de Fluxo

```
Cliente: "Quero criar um novo usuário"
↓
API recebe a requisição
↓
Controller verifica se os dados estão corretos
↓
Controller usa o Model Usuario para validar
↓
Controller salva os dados
↓
API retorna: "Usuário criado com sucesso!"
```

## Por que este Projeto é Útil?

- Permite criar aplicações acessíveis por:
  - Sites
  - Aplicativos móveis
  - Outros programas
- Mantém os dados organizados
- Facilita a manutenção
- Permite escalar a aplicação

## Tecnologias Utilizadas

- **C#**: Linguagem de programação principal
- **.NET 9.0**: Plataforma de execução
- **ASP.NET Core**: Framework para desenvolvimento web
- **Swagger/OpenAPI**: Documentação da API

## Como Executar o Projeto

1. Certifique-se de ter o .NET SDK instalado
2. Clone o repositório
3. Navegue até a pasta do projeto
4. Execute o comando:
```bash
dotnet run
```
5. Acesse a documentação Swagger em: `https://localhost:5001/swagger`

## Contribuição

Este é um projeto de aprendizado. Sinta-se à vontade para:
- Fazer sugestões
- Reportar problemas
- Contribuir com melhorias

## Licença

Este projeto está sob a licença MIT. 