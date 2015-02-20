#Push para Android com Azure 

Para utilizar o código de exemplo siga os seguintes passos:

###Android

- Substituir o valor da varíavel SENDER_ID pelo Id de seu projeto no GCM
- Substituir o valor da varíavel connectionString pela sua cadeia de conexão "DefaultListenSharedAccessSignature" de seu NotificationHub referente ao seu mobile-service.
- Substituir o valor do primeiro Parametro do NotificationHub, pelo nome de seu NotificationHub.

###Script Azure

- Substitua o código de seu Script de Inserir de sua tabela no Azure pelo código do arquivo Inserir.js

###Testando o App

- Instale a extensão do Postman no seu Google Chrome.
- Ao abrir o postman, na barra de endereços coloque o endereço de url do seu mobile-service do azure.
- O endereço deve ficar no seguinte formato: https://{meu-mobile-service}.azure-mobile.net/tables/{minha-tabela}
- No combobox ao lado selecione a opção "POST"
- Clique no botão Headers e adicione o header: X-ZUMO-APPLICATION, e como valor utilize a chave de seu mobile-service
- No body mais abaixo, selecione a opção "raw" e na combo ao lado selecione "JSON(application/json)"
- Na caixa de texto abaixo adicione o seguinte JSON: {"Mensagem":"Hello World"}
- Pressione o botão "Send"
