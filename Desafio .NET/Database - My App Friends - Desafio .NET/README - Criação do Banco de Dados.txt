É recomendado que para a criação do banco de dados que você vá no arquivo
“appsettings.json” e altere a “ConnectionString” que se encontra no mesmo para os
dados do seu DB, em seguida , no Visual Studio 2019, 
vá em Ferramentas >  Gerenciador de pacotes do NuGet e digite o seguinte comando no 
Console: Update-Database

A Ferramenta do EF criará o banco de dados em conjunto com o SQL Server.
