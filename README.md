# API de ativos Bitcoin
Essa é uma aplicação feita .NET core que busca e trata os dados dos últimos 30 pregões na API do Yahoo finance para disponibilizar corretamente para o app [asset_variation](https://github.com/douglas77costa/asset_variation "asset_variation"), pode ser consultado a documentação da API swagger [aqui](https://asset-variation-api.azurewebsites.net/swagger/index.html "aqui").


## Como começar
- Para executar aplicação com backend local, é necessário clonar o repositório e abri-lo em seu editor .NET favorito (Visual Studio, VSCode, Rider, etc) utiliza .NET core 7. Não é necessário configuração com Banco de dados, pois, optei por consultar diretamente a api do Yahoo Finance de modo a otimizar o tempo de desenvolvimento e de sincronia de dados.
- Alterar também o arquivo [launchSettings](https://github.com/douglas77costa/AssetVariationApi/blob/main/AssetVariationApi/Properties/launchSettings.json) para apontar para o IP local onde está executando a aplicação.

