# Mini Project API
contoh project kecil
* REST API
* Microservices
* Relational Database
* Transactional function (CRUD)
---
* pembuat : [Ayus](https://github.com/anggareta)

## Cara memulai
* harus tersedia/ter-install **docker** service pada PC/server/mesin
* buka **cmd**, masuk ke *root project*
* jalankan **CLI** `docker-compose` ( tunggu sampai selesai ):
```cmd
docker-compose up
```
* aplikasi akan otomatis membuat skema database
> *catatan*: port yang digunakan pada seting awal `:8080`

## Jika ingin menjalankan aplikasi tanpa docker
* install SQL Server
* install .Net 7 ( dotnet core version 7.0.x )
* seting *password database*
* buka **cmd**, masuk ke *root project*
* jalankan **CLI** `dotnet` :
```cmd
dotnet restore
```
```cmd
dotnet run
```
atau :
```cmd
dotnet build
```
* jalankan file `*.exe` ( jika menggunakan `dotnet build` )
* aplikasi akan otomatis membuat skema database
> jika aplikasi **API** sudah jalan, maka dapat dilakukan test dengan *Postman* atau **API** tester lainnya ( misal: RESTED di *FireFox* ), **Posman Collection** sudah tersedia di **Git** repository ini.

## Jika ingin debug aplikasi
jika ingin melakukan debug apliksi, database dapat ter-install di PC/mesin atau menggunakan **docker**, berikut untuk menggunakan **SQL Server** pada **docker**.
#### memulai SQL Server :
```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```
* install .Net 7 SDK ( dotnet core version 7.0.x )
* seting *password database*
* buka **cmd**, masuk ke *root project*
* jalankan **CLI** `dotnet` :
```cmd
dotnet run
```
---
> *perhatikan password harus sama pada saat seting database dan aplikasi*