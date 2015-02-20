#Push para Android com Azure 

Para utilizar o c�digo de exemplo siga os seguintes passos:

###Android

- Substituir o valor da var�avel SENDER_ID pelo Id de seu projeto no GCM
- Substituir o valor da var�avel connectionString pela sua cadeia de conex�o "DefaultListenSharedAccessSignature" de seu NotificationHub referente ao seu mobile-service.
- Substituir o valor do primeiro Parametro do NotificationHub, pelo nome de seu NotificationHub.

###Script Azure

- Substitua o c�digo de seu Script de Inserir de sua tabela no Azure pelo c�digo do arquivo Inserir.js

###Testando o App

- Instale a extens�o do Postman no seu Google Chrome.
- Ao abrir o postman, na barra de endere�os coloque o endere�o de url do seu mobile-service do azure.
- O endere�o deve ficar no seguinte formato: https://{meu-mobile-service}.azure-mobile.net/tables/{minha-tabela}
- No combobox ao lado selecione a op��o "POST"
- Clique no bot�o Headers e adicione o header: X-ZUMO-APPLICATION, e como valor utilize a chave de seu mobile-service
- No body mais abaixo, selecione a op��o "raw" e na combo ao lado selecione "JSON(application/json)"
- Na caixa de texto abaixo adicione o seguinte JSON: {"Mensagem":"Hello World"}
- Pressione o bot�o "Send"
