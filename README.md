# Super Hero API

* .Net7 Minimal Api
* Entity Framework Core 
* SQL Server
* clean architecture 
* repository pattern
* CQRS MediatR
  
## API  
### 查詢Super Hero by ID
**GET /api/SuperHero/{id}**
* Path params
  * id (int)

### 更新Super Hero by ID
**PUT /api/SuperHero/{id}**
* Headers
  * Content-Type: application/json
* Path params
  * id (int) 
* Body params
  * name (string)
  * place (string)

### 刪除Super Hero by ID
**DELETE /api/SuperHero/{id}**
* Path params
  * id (int)
  
### 新增Super Hero 
**POST /api/SuperHero**
* Headers
  * Content-Type: application/json
* Body params
  * name (string)
  * place (string)

### 查詢所有Super Hero
**GET /api/SuperHero**



