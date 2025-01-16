# Web API - Previsão do Tempo 🌦️

Este projeto é uma **Azure Function** que fornece informações de previsão do tempo para uma cidade específica, utilizando a API do OpenWeatherMap.

## 🚀 Como Funciona?

- Você envia uma solicitação HTTP GET para a rota:
/api/weather/{city}

- Substitua `{city}` pelo nome da cidade que deseja consultar.

### Exemplo:

GET http://localhost:7071/api/weather/Recife


---

## 🛠️ Pré-requisitos
- **.NET 8 SDK**
- **Azure Functions Core Tools**
- **Conta no OpenWeatherMap** para obter a chave de API.

---

## 📦 Instalação e Uso Local

1. Clone este repositório.
2. No terminal, navegue até a pasta do projeto.
3. Atualize o arquivo `PrevisaoTempo.cs` com sua chave de API:
   ```csharp
   string apiKey = "SUA_API_KEY"; // Substitua pela sua chave


Execute o comando:
func start

Teste a API localmente:
GET http://localhost:7071/api/weather/Recife



